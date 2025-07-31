using UnityEngine;

public class Tank : Player
{
    float protection = 1.5f;
    float strength = 0.75f;
    public override void InflictDamage(float damageAmount)
    {
        float increasedDamage = damageAmount * protection;
        damageAmount += increasedDamage;
        base.InflictDamage(damageAmount);
    }

    public override void TakeDamage(float damageAmount)
    {
        float reducedDamage = damageAmount * strength;
        damageAmount -= reducedDamage;
        base.TakeDamage(damageAmount);
    }
}
