using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.SceneManagement;

public class Scout : Action
{
    public string survivorName;
    float findSurvivorChance = 0.0f;
    float totalSearchTime = 10.0f;
    float possibleFindTime = 8.0f;

    public override void InitAction(string action)
    {
        //not all actions load scenes
        base.InitAction(action);
        GameManager.Instance.LoadActionScene(action);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (SceneManager.GetActiveScene().name.Contains("Scout"))
        {
            findSurvivorChance = Player.Instance.GetStat(0) / 10.0f;
            StartCoroutine(SearchForSurvivors(totalSearchTime));
        }
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

        if (findSurvivorChance > chance)
        {
            StartCoroutine(SpawnSurvivor(duration - elapsed));
        }
        else
        {
            GameManager.Instance.LoadPrevScene();
        }
    }

    IEnumerator SpawnSurvivor(float duration)
    {
        duration += 5.0f;
        DialogueController.Instance.SetDialgoue("Someone's there! It's " + survivorName + "!");
        Object survivor = Resources.Load("Survivors/" + survivorName);
        GameObject survivorInstance = (GameObject)GameObject.Instantiate(survivor);

        float elapsed = 0.0f;
        
        while(elapsed < duration)
        {
            elapsed += Time.deltaTime;

            yield return null;
        }

        GameManager.Instance.LoadPrevScene();
    }


}
