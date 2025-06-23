using TMPro;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public static DialogueController Instance;
    public TextMeshProUGUI dialogue;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetDialgoue(string newDialogue)
    {
        dialogue.text = newDialogue;
    }

    public void SetDowntownDialogue()
    {
        dialogue.text = "What happened to downtown LA...";

    }
}
