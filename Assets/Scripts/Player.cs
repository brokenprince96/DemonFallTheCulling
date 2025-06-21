using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    Animator animator;
    float m_health = 1.0f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public float PlayAnimation(string name)
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger(name);

        RuntimeAnimatorController controller = animator.runtimeAnimatorController;

        // Loop through all animation clips in the controller
        foreach (AnimationClip clip in controller.animationClips)
        {
            if (clip.name.Contains(name))
                return clip.length;
        }

        return -1.0f;
    }

    public float GetHealth()
    {
        return m_health;
    }
}
