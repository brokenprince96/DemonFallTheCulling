using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : Action
{
    public override void Use()
    {
        base.Use();
        actionLength = player.PlayAnimation("move");
        
        Debug.Log($"action length: {actionLength}");

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
