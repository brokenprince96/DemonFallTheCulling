using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Adding adjustments
public class ThrowController : MonoBehaviour
{
    public List<Button> throwButtons; // Assigned via Inspector
    public GameObject playerGameObject; // Assigned via Inspector
    Player player;
    public TextMeshProUGUI throwsRemainingText;
    int numThrowsRemaining = 3;

    private void Awake()
    {
        player = playerGameObject.GetComponent<Player>();
        throwsRemainingText.text = "Remaining moves: " + numThrowsRemaining;


        for (int i = 0; i < throwButtons.Count; i++)
        {
            int index = i; // VERY IMPORTANT: capture index locally!

            string buttonName = throwButtons[i].gameObject.name;

            throwButtons[i].onClick.AddListener(() => OnActionClicked(buttonName));
        }
    }

    void OnActionClicked(string buttonName)
    {
        throwsRemainingText.text = "Remaining moves: " + --numThrowsRemaining;
        player.Throw(buttonName);
    }
}
