using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    private const int MaxSize = 3; // Set your inventory size limit
    private Supply[] supplies = new Supply[MaxSize];
    List<Image> inventoryImages = new List<Image>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateUI()
    {
        Image[] childImageComponents = GetComponentsInChildren<Image>();

        for (int i = 0; i < childImageComponents.Length; i++)
        {
            if (childImageComponents[i].name.Contains("InventoryImage"))
            {
                inventoryImages.Add(childImageComponents[i]);
            }
        }

        for (int i = 0; i < supplies.Length; i++)
        {
            if (supplies[i] != null)
            {
                inventoryImages[i].sprite = supplies[i].GetImage();
                inventoryImages[i].color = Color.white; //image is white square if no sprite
            }
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
                newSupply.SetImage();
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
