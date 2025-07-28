using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AttackController : MonoBehaviour
{
    public List<Button> attackButtons; // Assigned via Inspector
    public GameObject playerGameObject; // Assigned via Inspector
    Player player; 
    public TextMeshProUGUI attacksRemainingText;
    int numAttacksRemaining = 5;

    private void Awake()
    {
        player = playerGameObject.GetComponent<Player>();
        attacksRemainingText.text = "Remaining moves: " + numAttacksRemaining;


        for (int i = 0; i < attackButtons.Count; i++)
        {
            int index = i; // VERY IMPORTANT: capture index locally!

            string buttonName = attackButtons[i].gameObject.name;

            attackButtons[i].onClick.AddListener(() => OnActionClicked(buttonName));
        }
    }

    void OnActionClicked(string buttonName)
    {
        attacksRemainingText.text = "Remaining moves: " + --numAttacksRemaining;
        player.Attack(buttonName);
    }
}
