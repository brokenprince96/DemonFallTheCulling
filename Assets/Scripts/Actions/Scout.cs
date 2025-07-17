using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

        findSurvivorChance = StatController.Instance.GetStat(0) / 10.0f;
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

    }

    IEnumerator SpawnSurvivor(float duration)
    {
        duration += 5.0f;
        DialogueController.Instance.SetDialgoue("Someone's there!");
        Sprite[] sprites = Resources.LoadAll<Sprite>("SurvivorImages");
        PartyController.Instance.AddSurvivor(sprites[survivorIndex++]);

        float elapsed = 0.0f;
        
        while(elapsed < duration)
        {
            elapsed += Time.deltaTime;

            yield return null;
        }
    }
}
