using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 1.0f;
    public Animator animator;

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        animator.SetTrigger("damage");
    }
}
