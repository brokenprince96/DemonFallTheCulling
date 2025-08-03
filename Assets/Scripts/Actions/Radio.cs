using System.Collections;
using UnityEngine;

public class Radio : Action
{
    public override void InitAction(string action)
    {
        base.InitAction(action);

        GameManager.Instance.IncreaseStat(0);

        StartCoroutine(SendOutRadio(5.0f));
    }

    IEnumerator SendOutRadio(float duration)
    {
        float elapsed = 0.0f;
        string baseText = "Sending out some signals";
        int dotCount = 0;
        float dt = 0.5f;

        while (elapsed < duration)
        {
            elapsed += dt;

            dotCount = (dotCount % 3) + 1; // Cycle 1 2 3
            string dots = new('.', dotCount);
            DialogueController.Instance.SetDialgoue(baseText + dots);

            yield return new WaitForSeconds(dt); // Adjust timing if needed
        }

        DialogueController.Instance.SetDialgoue("I wonder if anyone else heard that...");

        EndAction();
    }
}
