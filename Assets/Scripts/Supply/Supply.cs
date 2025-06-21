using UnityEngine;
using UnityEngine.UI;

public class Supply
{
    protected Sprite image;
    Sprite[] sprites = new Sprite[10];

    public virtual void Use()
    {
    }

    public void SetImage()
    {
        sprites = Resources.LoadAll<Sprite>(GetType() + "Images");
        image = sprites[0];
    }

    public Sprite GetImage()
    {
        return image;
    }
}
