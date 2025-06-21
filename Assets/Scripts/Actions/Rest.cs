using UnityEngine;

public class Rest : Action
{
    public override void Use()
    {
        base.Use();
        Debug.Log("resting...");
    }
}
