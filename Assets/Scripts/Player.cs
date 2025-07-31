using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public Enemy enemy;
    public Animator animator;
    public Slider healthSlider;

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

    public void Attack(string attack)
    {
        animator.SetTrigger(attack);
    }

    public void InflictDamage(float damageAmount)
    {
        enemy.TakeDamage(damageAmount);
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        healthSlider.value = health;
    }

}
