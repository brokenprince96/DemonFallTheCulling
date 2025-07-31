using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public Enemy enemy;
    public Animator animator;
 
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

    public void Attack(string attack)
    {
        animator.SetTrigger(attack);
    }

    public void InflictDamage(float damageAmount)
    {
        enemy.TakeDamage(damageAmount);
    }

}
