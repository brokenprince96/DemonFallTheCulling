using System.Collections;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    public Enemy enemy;
    bool playersTurn = true;

    private void Start()
    {
        DialogueController.Instance.SetDialgoue("Player goes first!");
    }

    public bool PlayerCanAttack()
    {
        return playersTurn;
    }

    public void EndTurn()
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

        playersTurn = !playersTurn;

        if (playersTurn)
        {
            DialogueController.Instance.SetDialgoue("Player's turn!");
        }
        else
        {
            DialogueController.Instance.SetDialgoue("Enemy's turn!");
            enemy.Attack();
        }

    }
}
