using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Enemy enemy;
    public Animator animator;
    public Slider healthSlider;
    public FightManager fightManager;
    float health = 1.0f;
 
    //called on button pressed
    public void Attack(string attack)
    {
        if(fightManager.PlayerCanAttack())
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
        fightManager.EndTurn();
    }

}
