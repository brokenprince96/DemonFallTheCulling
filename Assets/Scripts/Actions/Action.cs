using System.Collections;
using UnityEngine;

public class Action : MonoBehaviour
{
    static protected int interupt = 0;
    static protected bool actionRunning = false;
    protected float interuptTime = 0.0f;

    float enemyEncounterChance = 0.5f;
    float scriptedEventChance = 0.2f;

    //called when ANY action button is clicked
    public virtual void InitAction(string action)
    {
        actionRunning = true;
        float encounterEnemy = Random.Range(0.0f, 1.0f);
        float scriptedEvent = Random.Range(0.0f, 1.0f);

        if (encounterEnemy <= enemyEncounterChance)
        {
            interupt = 1;
        }
        else if (scriptedEvent <= scriptedEventChance)
        {
            interupt = 2;
        }

        int dayActionsRemaining = GameManager.Instance.GetRemainingDayActions();

        if (GameManager.Instance.GetRemainingDayActions() == 0)
        {
            interupt = 3;
        }
    }

    public virtual void HandleInterruption(int interruptCode)
    {
        DialogueController.Instance.SetDialgoue("Enemy encountered!");
        actionRunning = false;
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
    }

    public virtual void EndAction()
    {
        Debug.Log("EndAction() time: " + Time.time.ToString());

        if(interupt == 3)
        {
            GameManager.Instance.NightFall();
        }
        actionRunning = false;
    }

    public bool running()
    {
        return actionRunning;
    }
}
