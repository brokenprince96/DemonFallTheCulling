using UnityEngine;
using UnityEngine.UI;

public class Food : Supply
{
    string[] names = { "apple" };

    public override void Use()
    {
        Debug.Log("use food");
    }

    public override void SetImage()
    {
        image = Resources.Load<Sprite>("FoodImages/apple");
        Debug.Log("Set image food");
    }

    public override Sprite GetImage()
    {
        return image;
    }
}
