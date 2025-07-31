using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightManager : MonoBehaviour
{
    public Enemy enemy;
    bool playersTurn = true;
    bool fightOver = false;

    private void Start()
    {
        DialogueController.Instance.SetDialgoue("Player goes first!");
    }

    public bool PlayerCanAttack()
    {
        return playersTurn;
    }

    public void EndFight(bool playerWins)
    {
        fightOver = true;

        if(playerWins)
        {
            DialogueController.Instance.SetDialgoue("Player wins! Perception increased!");
            GameManager.Instance.IncreaseStat(0);
        }
        else
        {
            DialogueController.Instance.SetDialgoue("Enemy wins!");
        }

        StartCoroutine(LoadMainSceneCooldown(3.0f));
    }

    public void EndTurn()
    {
        if(!fightOver)
            StartCoroutine(ChangeTurns(1.0f));
    }

    IEnumerator LoadMainSceneCooldown(float duration)
    {
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            yield return null;
        }
        int previousSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
        SceneManager.LoadScene(previousSceneIndex);
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
