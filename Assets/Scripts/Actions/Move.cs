
using System.Collections;
using UnityEngine;

public class Move : Action
{
    //called when button is clicked
    public override void InitAction(string action)
    {
        base.InitAction(action);

        DialogueController.Instance.SetDialgoue("Lets keep going...");
        StartCoroutine(Moving(5.0f));
    }

    IEnumerator Moving(float duration)
    {
        float elapsed = 0.0f;

        while(elapsed < duration)
        {
            elapsed += Time.deltaTime;
            yield return null;
        }

        DialogueController.Instance.SetDialgoue("Downtown LA is not looking too good...");
    }

}
