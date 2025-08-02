using UnityEngine;

public class Survivor
{
    protected Sprite image;
    const int numSurvivors = 10;
    Sprite[] sprites = new Sprite[numSurvivors];

    public Survivor()
    {
        int survivorIndex = Party.Instance.GetPartyMembers().Count;

        if (survivorIndex < numSurvivors)
        {
            sprites = Resources.LoadAll<Sprite>("SurvivorImages");
            Debug.Log("load image:" + survivorIndex);
            image = sprites[survivorIndex];
        }
    }

    public Sprite GetImage()
    {
        return image;
    }
}
