using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;
    float m_health = 1.0f;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public float PlayAnimation(string name)
    {
        animator.SetTrigger(name);

        RuntimeAnimatorController controller = animator.runtimeAnimatorController;

        // Loop through all animation clips in the controller
        foreach (AnimationClip clip in controller.animationClips)
        {
            if (clip.name.Contains("Move"))
                return clip.length;
        }

        return -1.0f;
    }

    public float GetHealth()
    {
        return m_health;
    }
}
