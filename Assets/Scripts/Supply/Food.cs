using UnityEngine;
using UnityEngine.UI;

public class Food : Supply
{
    public override void Use()
    {
        Debug.Log("use food");
    }

}
