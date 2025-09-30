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

    // added the player for more damage
    public override void InflictMoreDamage(float damageAmount = 0.2f)
    {
        DialogueController.Instance.SetDialgoue("Tank's strength ability increases more damage output!");
        float increasedDamage = damageAmount * strength;
        damageAmount += increasedDamage;
        base.InflictMoreDamage(damageAmount);
    }

    public override void TakeDamage(float damageAmount)
    {
        DialogueController.Instance.SetDialgoue("Tank's protection ability decreases damage taken!");
        float reducedDamage = damageAmount * protection;
        damageAmount -= reducedDamage;
        base.TakeDamage(damageAmount);
    }
    // added the players more damage
    public override void TakeMoreDamage(float damageAmount = 0.2f)
    {
        DialogueController.Instance.SetDialgoue("Tank's protection ability decreases more damage taken!");
        float reducedDamage = damageAmount * protection;
        damageAmount -= reducedDamage;
        base.TakeMoreDamage(damageAmount);
    }
}
