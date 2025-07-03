using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    Animator animator;

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
        animator.Play(name);

        RuntimeAnimatorController controller = animator.runtimeAnimatorController;

        // Loop through all animation clips in the controller
        foreach (AnimationClip clip in controller.animationClips)
        {
            if (clip.name.Contains(name))
                return clip.length;
        }

        return -1.0f;
    }


}
