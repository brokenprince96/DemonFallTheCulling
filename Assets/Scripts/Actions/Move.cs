
using System.Collections;
using UnityEngine;

public class Move : Action
{
    //called when button is clicked
    public override void InitAction(string action)
    {
        base.InitAction(action);

        StartCoroutine(Moving(5.0f));
    }

    IEnumerator Moving(float duration)
    {
        float elapsed = 0.0f;
        float dt = 0.5f;
        int dotCount = 3;
        string baseText = "Lets keep going";
        interuptTime = Random.Range(0.2f, duration - 0.1f);

        while(elapsed < duration)
        {
            elapsed += dt;

            dotCount = (dotCount % 3) + 1; // Cycle 1 2 3
            string dots = new('.', dotCount);
            DialogueController.Instance.SetDialgoue(baseText + dots);

            if (interupt != 0 && elapsed > interuptTime)
            {
                HandleInterruption(interupt);
                yield break;
            }

            yield return new WaitForSeconds(dt); // Adjust timing if needed
        }

        DialogueController.Instance.SetDialgoue("Downtown LA is not looking too good...");
    }

}
