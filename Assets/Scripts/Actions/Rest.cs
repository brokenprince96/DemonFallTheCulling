using System.Collections;
using UnityEngine;

public class Rest : Action
{
    public override void InitAction(string action)
    {
        base.InitAction(action);

        StartCoroutine(SleepyTime(5.0f));
    }

    IEnumerator SleepyTime(float duration)
    {
        float elapsed = 0.0f;
        float dt = 0.5f;
        int dotCount = 3;
        string baseText = "Taking a rest";
        while(elapsed < duration)
        {
            elapsed += dt;
            dotCount = (dotCount % 3) + 1; // Cycle 1 2 3
            string dots = new('.', dotCount);
            DialogueController.Instance.SetDialgoue(baseText + dots);
            yield return new WaitForSeconds(dt); // Adjust timing if needed
        }

        DialogueController.Instance.SetDialgoue("Downtown LA is cursed, how can it be fixed?");
    }
}
