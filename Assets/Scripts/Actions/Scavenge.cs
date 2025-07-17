using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scavenge : Action
{
    float scavengeTime = 5.0f;
    static float interuptTime = -1.0f;
    const int numSupply = 3;
    Supply[] supply = new Supply[numSupply];

    // Prepare a list of possible supplies to choose from
    Supply[] findableSupplies = new Supply[] { new Food(), new Tool() };

    public override void InitAction(string action)
    {
        base.InitAction(action);

        DialogueController.Instance.SetDialgoue("Lets see if we can find some supplies...");

        // Randomly assign supplies to the array
        for (int i = 0; i < supply.Length; i++)
        {
            int randomIndex = Random.Range(0, findableSupplies.Length);
            supply[i] = findableSupplies[randomIndex];
        }

        interuptTime = Random.Range(scavengeTime / 2, scavengeTime - 1.0f);

        StartCoroutine(SearchForSupplies(scavengeTime));
    }

    IEnumerator SearchForSupplies(float duration)
    {
        float elapsed = 0f;

        //Generate 3 unique sorted supply times
        List<float> supplyTimes = new List<float>();
        for (int i = 0; i < numSupply; i++)
            supplyTimes.Add(Random.Range(0.5f, duration - 0.5f)); // avoid too close to 0 or end

        supplyTimes.Sort(); // ensure they trigger in order

        int supplyIndex = 0;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;


            if (interupt != 0 && elapsed > interuptTime)
            {
                HandleInterruption(interupt);
                yield break;
            }

            //Check for supply time match
            if (supplyIndex < supplyTimes.Count && elapsed >= supplyTimes[supplyIndex])
            {
                Inventory.Instance.AddSupply(supply[supplyIndex]);
                supplyIndex++;
            }

            actionLength = 0;
            yield return null;
        }

    }

    void HandleInterruption(int interruptCode)
    {
        switch (interruptCode)
        {
            case 1:
                Debug.Log("Enemy Encountered!");
                GameManager.Instance.LoadActionScene("EnemyEncounter");
                break;

            case 2:
                Debug.Log("scripted event");
                break;

            default:
                Debug.Log("Unknown interruption.");
                break;
        }

        interupt = 0;
        actionLength = 0;
    }

}
