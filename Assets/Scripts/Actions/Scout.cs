using System.Collections;
using UnityEngine;

public class Scout : Action
{
    float findSurvivorChance = 0.0f;
    float totalSearchTime = 5.0f;
    int survivorIndex = 0;
    int numSurvivors = 9;

    public override void InitAction(string action)
    {
        //not all actions load scenes
        base.InitAction(action);

        //stat 0 is perception
        findSurvivorChance = GameManager.Instance.GetStat(0) / 10.0f; // stat range 1-10, chance range 0-1
        findSurvivorChance = 1.0f;
        StartCoroutine(SearchForSurvivors(totalSearchTime));
    }

    IEnumerator SearchForSurvivors(float duration)
    {
        float chance = Random.Range(0.0f, 1.0f);
        float elapsed = 0f;
        float dt = 0.5f;
        int dotCount = 3;
        string baseText = "Lets see if we can find anyone";

        while (elapsed < duration)
        {
            elapsed += dt;

            dotCount = (dotCount % 3) + 1; // Cycle 1 2 3
            string dots = new string('.', dotCount);
            DialogueController.Instance.SetDialgoue(baseText + dots);
            yield return new WaitForSeconds(dt); // Adjust timing if needed
            
        }

        if (findSurvivorChance > chance && survivorIndex < numSurvivors)
            StartCoroutine(SpawnSurvivor(duration - elapsed));
        else
            DialogueController.Instance.SetDialgoue("No one found");

        EndAction();
    }

    IEnumerator SpawnSurvivor(float duration)
    {
        duration += 3.0f;
        DialogueController.Instance.SetDialgoue("Someone's there!");
        Party.Instance.AddPartyMemeber();
        float elapsed = 0.0f;
        while(elapsed < duration)
        {
            elapsed += Time.deltaTime;
            yield return null;
        }
    }
}
