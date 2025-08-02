using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    List<Supply> supplies = new List<Supply>();
    
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
    public void AddSupply()
    {
        Supply supply = new Supply();
        supplies.Add(supply);
        
    }

    public List<Supply> GetSupplies()
    {
        return supplies;
    }
}
