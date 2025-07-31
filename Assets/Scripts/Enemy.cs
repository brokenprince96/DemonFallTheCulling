using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float health = 1.0f;
    public Animator animator;
    public Slider slider;

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        animator.SetTrigger("damage");
        slider.value = health;
    }
}
