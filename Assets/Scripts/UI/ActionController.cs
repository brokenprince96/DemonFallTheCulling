using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActionController : MonoBehaviour
{
    public List<Button> actionButtons; // Assigned via Inspector
    public List<Action> possibleActions; // Assigned via Inspector
    public TextMeshProUGUI dayActionsRemaining;

    private void Awake()
    {
        for (int i = 0; i < actionButtons.Count; i++)
        {
            int index = i; // VERY IMPORTANT: capture index locally!

            string buttonName = actionButtons[i].gameObject.name;

            actionButtons[i].onClick.AddListener(() => OnActionClicked(buttonName));
            possibleActions.Add(actionButtons[i].gameObject.GetComponent<Action>());

        }
    }

    private void Start()
    {
        int numDayActions = GameManager.Instance.GetRemainingDayActions();
        dayActionsRemaining.text = "Day Actions Remaining: " + numDayActions;
    }

    void OnActionClicked(string buttonName)
    {
        for(int i = 0; i < possibleActions.Count; i++)
        {
            if(buttonName == possibleActions[i].GetType().ToString())
            {
                GameManager.Instance.UseDayAction();
                int numDayActions = GameManager.Instance.GetRemainingDayActions();
                dayActionsRemaining.text = "Day Actions Remaining: " + numDayActions;
                possibleActions[i].InitAction(buttonName);
            }
        }
    }

}
