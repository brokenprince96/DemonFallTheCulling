using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    Animator animator;
    Stats stats = new Stats();
    float health = 1.0f;


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

    public void IncreaseStat(int stat)
    {
        switch (stat)
        {
            case 0:
                stats.perception++;
                break; 
            default:
                Debug.LogWarning("stat doesn't exist");
                break; 
        }
    }

    public int GetStat(int stat)
    {
        switch (stat)
        {
            case 0:
                Debug.Log("returning perception level: " + stats.perception);
                return stats.perception;
            default:
                Debug.LogWarning("stat doesn't exist");
                break;
        }

        return -1;
    }

    public float GetHealth()
    {
        return health;
    }
}
