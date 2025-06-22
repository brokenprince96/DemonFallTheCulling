using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scout : Action
{
    public string survivorName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (SceneManager.GetActiveScene().name.Contains("Scout"))
        {
            Debug.Log("start scouting!");
            StartCoroutine(SearchForSurvivors(10.0f));
        }
    }

    IEnumerator SearchForSurvivors(float duration)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            Debug.Log(elapsed + ": Searching for " + survivorName + "...");

            if (elapsed > 8.0f)
            {
                SpawnSurvivor();
                yield break;
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
