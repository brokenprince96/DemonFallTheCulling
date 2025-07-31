using System.Collections;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    public Enemy enemy;

    public void EndPlayersTurn()
    {
        StartCoroutine(ChangeTurns(1.0f));
    }

    IEnumerator ChangeTurns(float duration)
    {
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            yield return null;
        }

        enemy.Attack();
    }
}
