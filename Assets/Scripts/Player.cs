using Mono.Cecil.Cil;
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

    // new Code to be added for throw 
    public void Throw(string throws)
    {
        if(fightManager.PlayerCanAttack())
            animator.SetTrigger(throws);
    }

    public virtual void InflictDamage(float damageAmount)
    {
        enemy.TakeDamage(damageAmount);
    }

    // New code added for more damage
    public virtual void InflictMoreDamage(float damageAmount = 0.2f)
    {
        enemy.TakeMoreDamage(damageAmount);
    }

    public virtual void TakeDamage(float damageAmount)
    {
        animator.SetTrigger("damage");
        health -= damageAmount;
        healthSlider.value = health;
    }

    public virtual void TakeMoreDamage(float damageAmount = 0.2f)
    {

        animator.SetTrigger("extra damage");
        health -= damageAmount;
        healthSlider.value = health;
    }

    //call with event at the end of the attack animation
    public void EndTurn()
    {
        fightManager.EndTurn();
    }

}
