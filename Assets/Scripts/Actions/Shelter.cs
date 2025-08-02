using System.Collections;
using UnityEngine;

public class Shelter : Action
{
    public override void InitAction(string action)
    {
        base.InitAction(action);

        StartCoroutine(Build(5.0f));
    }

    IEnumerator Build(float duration)
    {
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            DialogueController.Instance.SetDialgoue("Building shelter...");
            yield return null;
        }

        DialogueController.Instance.SetDialgoue("This shelter helps a little");

        EndAction();
    }
}
