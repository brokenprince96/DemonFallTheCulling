using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionController : MonoBehaviour
{
    public List<Button> actionButtons; // Assigned via Inspector
    public List<Action> possibleActions; // Assigned via Inspector

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

    void OnActionClicked(string buttonName)
    {
        for(int i = 0; i < possibleActions.Count; i++)
        {
            if(buttonName == possibleActions[i].GetType().ToString())
            {
                possibleActions[i].InitAction(buttonName);
            }
        }
    }

}
