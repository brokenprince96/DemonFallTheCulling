using UnityEngine;

public class Tank : Player
{
    float strength = 1.5f;
    float protection = 0.75f;
    public override void InflictDamage(float damageAmount)
    {
        DialogueController.Instance.SetDialgoue("Tank's strength ability increases damage output!");
        float increasedDamage = damageAmount * strength;
        damageAmount += increasedDamage;
        base.InflictDamage(damageAmount);
    }

    public override void TakeDamage(float damageAmount)
    {
        DialogueController.Instance.SetDialgoue("Tank's protection ability decreases damage taken!");
        float reducedDamage = damageAmount * protection;
        damageAmount -= reducedDamage;
        base.TakeDamage(damageAmount);
    }
}
