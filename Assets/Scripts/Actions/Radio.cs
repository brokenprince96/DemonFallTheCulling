using UnityEngine;

public class Radio : Action
{
    public override void InitAction(string action)
    {
        base.InitAction(action);

        Player.Instance.PlayAnimation("Radio");
        Player.Instance.IncreaseStat(0);
    }
}
