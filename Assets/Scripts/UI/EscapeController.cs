using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscapeController : MonoBehaviour
{
    public List<Button> throwButtons; // Assigned via Inspector
    public GameObject playerGameObject; // Assigned via Inspector
    Player player;
    public TextMeshProUGUI escape;
    public int escapeChance = 50;
    public EscapeSkill bm;

    //Update is called once per frame
    public void OnEscapeAttempt()
    {
        player = playerGameObject.GetComponent<Player>();
        OnActionClicked("Escaping...");

        StartCoroutine(ResolveEscape());
    }

    private System.Collections.IEnumerator ResolveEscape()
    {
        // Wait for a second to simulate the escape attempt.
        yield return new WaitForSeconds(1.0f);
        FightManager fm = new FightManager();
       
        // to add an argument for EscapeChance
        if (Random.Range(0, 100) < escapeChance)
        {
            // Successful escape. End the battle.
            OnActionClicked("You successfully escaped!");
            yield return new WaitForSeconds(2.0f);
            EndBattle(true);
        }
        else
        {
            // Failed escape. Return to the next combat round.
            OnActionClicked("You failed to escape!");
            yield return new WaitForSeconds(2.0f);
            fm.EndTurn();
        }
    }

    void OnActionClicked(string buttonName)
    {
        if (escape != null)
        {
            escape.text = buttonName;
        }
    }
    private void EndBattle(bool success)
    {
        // Here you would add logic to transition out of combat.
        // For example, load a new scene or disable the battle UI.
        Debug.Log("Battle ended. Escape success: " + success);
        //gameObject.SetActive(false); // Example of disabling the battle.
    }
}
