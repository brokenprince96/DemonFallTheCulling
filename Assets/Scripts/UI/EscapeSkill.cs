using UnityEngine;

public class EscapeSkill : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private EscapeController battleManager;

    private void UseSkill()
    {
        if (battleManager != null)
        {
            battleManager.OnEscapeAttempt();
        }
    }
}

