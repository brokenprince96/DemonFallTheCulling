using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public Enemy enemy;
    public Animator animator;
    public Slider healthSlider;
    public FightManager fightManager;

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

    //called on button pressed
    public void Attack(string attack)
    {
        animator.SetTrigger(attack);
    }

    public virtual void InflictDamage(float damageAmount)
    {
        enemy.TakeDamage(damageAmount);
    }

    public virtual void TakeDamage(float damageAmount)
    {
        animator.SetTrigger("damage");
        health -= damageAmount;
        healthSlider.value = health;
    }

    //call with event at the end of the attack animation
    public void EndTurn()
    {
        fightManager.EndPlayersTurn();
    }

}
