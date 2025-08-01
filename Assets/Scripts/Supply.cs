using UnityEngine;

[System.Serializable]
public class Supply
{
    protected Sprite image;
    Sprite[] sprites = new Sprite[10]; 

    public Supply()
    {
        sprites = Resources.LoadAll<Sprite>("SupplyImages");
        int randomIndex = Random.Range(0, 2);
        image = sprites[randomIndex];
    }

    public Sprite GetImage()
    {
        return image;
    }
}
