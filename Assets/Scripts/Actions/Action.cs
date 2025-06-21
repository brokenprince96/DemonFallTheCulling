using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Action : MonoBehaviour
{
    static protected int interupt = 0;
    static protected float actionLength = 0;

    float enemyEncounterChance = -0.5f;
    float scriptedEventChance = -0.2f;

    //called when ANY action button is clicked
    public virtual void InitAction()
    {
        if (actionLength > 0)
            return;

        float encounterEnemy = Random.Range(0.0f, 1.0f);
        float scriptedEvent = Random.Range(0.0f, 1.0f);

        if(encounterEnemy <= enemyEncounterChance)
        {
            interupt = 1;
        }
        else if(scriptedEvent <= scriptedEventChance)
        {
            interupt = 2;
        }
    }

}
