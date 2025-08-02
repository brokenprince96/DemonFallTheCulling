using System.Collections.Generic;
using UnityEngine;

public class Party : MonoBehaviour
{
    public static Party Instance;
    List<Survivor> survivors = new List<Survivor>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Add supply to the first available slot
    public void AddPartyMemeber()
    {
        Survivor survivor = new Survivor();
        survivors.Add(survivor);
        PartyController.Instance.UpdateImages();
    }

    public List<Survivor> GetPartyMembers()
    {
        return survivors;
    }

}
