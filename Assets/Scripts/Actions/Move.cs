using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : Action
{
    //called when button is clicked
    public override void InitAction()
    {
        base.InitAction();
        actionLength = Player.Instance.PlayAnimation("move");
        StartCoroutine(WaitForAnimation(actionLength));
    }

    IEnumerator WaitForAnimation(float duration)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            yield return null;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
