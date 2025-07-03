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
        while(elapsed < duration)
        {
            elapsed += Time.deltaTime;

            DialogueController.Instance.SetDialgoue("YOU TIRED HUH");
            yield return null;
        }

        DialogueController.Instance.SetDialgoue("Downtown LA fucked");
    }
}
