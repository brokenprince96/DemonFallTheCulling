using System.Collections;
using UnityEngine;

public class Action : MonoBehaviour
{
    static protected int interupt = 0;
    static protected float actionLength = 0;
    protected float interuptTime = 0.0f;

    float enemyEncounterChance = 0.5f;
    float scriptedEventChance = 0.2f;

    //called when ANY action button is clicked
    public virtual void InitAction(string action)
    {
        float encounterEnemy = Random.Range(0.0f, 1.0f);
        float scriptedEvent = Random.Range(0.0f, 1.0f);

        if (encounterEnemy <= enemyEncounterChance)
        {
            interupt = 1;
        }
        else if(scriptedEvent <= scriptedEventChance)
        {
            interupt = 2;
        }

        if(GameManager.Instance.GetRemainingDayActions() == 0)
        {
            interupt = 3;
        }
    }

    public virtual void HandleInterruption(int interruptCode)
    {
        DialogueController.Instance.SetDialgoue("Enemy encountered!");
        StartCoroutine(InteruptWarmup(3.0f, interruptCode));
    }

    IEnumerator InteruptWarmup(float duration, int interruptCode)
    {
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            yield return null;
        }
        GameManager.Instance.LoadEnemyEncounterScene();
        interupt = 0;
        actionLength = 0;
    }

    public virtual void EndAction()
    {
        if(interupt == 3)
        {
            DialogueController.Instance.SetDialgoue("Night falls...");
        }
    }

}
