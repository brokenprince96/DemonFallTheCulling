using TMPro;
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
    }

    public virtual void HandleInterruption(int interruptCode)
    {
        switch (interruptCode)
        {
            case 1:
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
