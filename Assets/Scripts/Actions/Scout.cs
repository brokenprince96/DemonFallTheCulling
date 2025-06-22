using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scout : Action
{
    public string survivorName;
    float findSurvivorChance = 0.0f;
    float totalSearchTime = 10.0f;
    float possibleFindTime = 8.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (SceneManager.GetActiveScene().name.Contains("Scout"))
        {
            Debug.Log("start scouting!");
            findSurvivorChance = Player.Instance.GetStat(0) / 10.0f;
            StartCoroutine(SearchForSurvivors(totalSearchTime));
        }
    }

    IEnumerator SearchForSurvivors(float duration)
    {
        float chance = Random.Range(0.0f, 1.0f);
        float elapsed = 0f;

        Debug.Log(findSurvivorChance + " > " + chance);

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            if (elapsed > possibleFindTime)
            {
                if(findSurvivorChance > chance)
                {
                    SpawnSurvivor();
                    yield break;
                }
            }

            yield return null;
        }
    }

    void SpawnSurvivor()
    {
        Object survivor = Resources.Load("Survivors/" + survivorName);
        GameObject survivorInstance = (GameObject)GameObject.Instantiate(survivor);
    }

}
