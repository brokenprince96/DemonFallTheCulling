using UnityEngine;
using UnityEngine.UI;

public class Tool : Supply
{
    string[] names = { "hammer" };

    public override void Use()
    {
        Debug.Log("use tool");
    }

    public override void SetImage()
    {
        image = Resources.Load<Sprite>("ToolImages/hammer");
        Debug.Log("Set image tool");
    }

    public override Sprite GetImage()
    {
        return image;
    }
}
