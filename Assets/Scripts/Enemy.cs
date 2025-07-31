using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float health = 1.0f;
    public Animator animator;
    public Slider slider;
    public Player player;
    public FightManager fightManager;

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if(health <= 0.0f)
        {
            health = 0.0f;
            animator.SetTrigger("dead");
            fightManager.EndFight(true);
        }
        else
        {
            animator.SetTrigger("damage");
        }

        slider.value = health;
    }

    public void Attack()
    {
        animator.SetTrigger("melee");
    }

    public void InflictDamage(float damageAmount)
    {
        player.TakeDamage(damageAmount);
    }

    public void EndTurn()
    {
        fightManager.EndTurn();
    }
}
