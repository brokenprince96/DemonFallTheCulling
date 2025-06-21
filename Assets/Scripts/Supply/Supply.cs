using UnityEngine;
using UnityEngine.UI;

public abstract class Supply
{
    protected Sprite image;
    public abstract void Use();

    public abstract void SetImage();

    public abstract Sprite GetImage();
}
