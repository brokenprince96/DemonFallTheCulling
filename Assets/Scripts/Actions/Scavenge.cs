using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scavenge : Action
{
    float scavengeTime = 0.0f;
    static float interuptTime = -1.0f;
    const int numSupplies = 3;
    Supply[] findableSupplies = new Supply[numSupplies];

    // Prepare a list of possible supplies to choose from
    Supply[] possibleSupplies = new Supply[]
    {
    new Food(),
    new Tool()
    };

    //---------------------------------------------called when scavenge level is loaded-----------------------------------------------------------
    protected void Start()
    {
        //scavenge script must be in scavenge level
        if (SceneManager.GetActiveScene().name.Contains("Scavenge"))
        {
            scavengeTime = Player.Instance.PlayAnimation("Scavenge");

            // Randomly assign supplies to the array
            for (int i = 0; i < findableSupplies.Length; i++)
            {
                int randomIndex = Random.Range(0, possibleSupplies.Length);
                findableSupplies[i] = possibleSupplies[randomIndex];
            }

            if (interupt != 0)
                interuptTime = Random.Range(scavengeTime / 2, scavengeTime - 1.0f);


            StartCoroutine(SearchForSupplies(scavengeTime));
        }
    }

    IEnumerator SearchForSupplies(float duration)
    {
        float elapsed = 0f;

        // Step 1: Generate 3 unique sorted supply times
        List<float> supplyTimes = new List<float>();
        for (int i = 0; i < numSupplies; i++)
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

            // Step 3: Check for supply time match
            if (supplyIndex < supplyTimes.Count && elapsed >= supplyTimes[supplyIndex])
            {
                Inventory.Instance.AddSupply(findableSupplies[supplyIndex]);
                supplyIndex++;
            }

            actionLength = 0;
            yield return null;
        }

        GameManager.Instance.LoadPrevScene();
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
