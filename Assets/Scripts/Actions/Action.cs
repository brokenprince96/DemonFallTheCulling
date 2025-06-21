using UnityEngine;

public class Action : MonoBehaviour
{
    protected Player player;
    static protected int interupt = 0;
    static protected float actionLength = 0;

    float enemyEncounterChance = -0.5f;
    float scriptedEventChance = -0.2f;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    public virtual void Use()
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
