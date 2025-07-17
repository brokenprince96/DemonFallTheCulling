using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    private const int MaxSize = 3; // Set your inventory size limit
    private Supply[] supplies = new Supply[MaxSize];
    public List<Image> inventoryImages;

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
    public bool AddSupply(Supply newSupply)
    {
        for (int i = 0; i < supplies.Length; i++)
        {
            if (supplies[i] == null)
            {
                supplies[i] = newSupply;
                inventoryImages[i].sprite = supplies[i].GetImage();
                inventoryImages[i].color = Color.white; //image is transparent by default
                DialogueController.Instance.SetDialgoue(newSupply.GetType() + " added!");
                return true;
            }
        }

        DialogueController.Instance.SetDialgoue(newSupply.GetType() + " found but inventory is full!");

        return false;
    }

    public void UseSupply(int index)
    {
        if (index >= 0 && index < supplies.Length && supplies[index] != null)
        {
            supplies[index].Use();
            supplies[index] = null; // Remove after use (optional)
        }
        else
        {
            Debug.LogWarning("Invalid or empty slot.");
        }
    }

    public Supply[] GetSupplies()
    {
        return supplies;
    }
}
