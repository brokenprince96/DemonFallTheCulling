using UnityEngine;
using UnityEngine.UI;

public class Supply
{
    protected Sprite image;
    Sprite[] sprites = new Sprite[10]; //current supply types are food and tool, each with various images

    public virtual void Use()
    {
    }

    public Sprite GetImage()
    {
        sprites = Resources.LoadAll<Sprite>(GetType() + "Images");
        image = sprites[0];

        return image;
    }
}
