using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public Button openButton;
    public Button closeButton;

    public List<Button> supplyButtons; // Assigned via Inspector
    public List<Image> inventoryImages;

    void Start()
    {
        for (int i = 0; i < supplyButtons.Count; i++)
        {
            int index = i; // VERY IMPORTANT: capture index locally!
            supplyButtons[i].onClick.AddListener(() => OnSupplyClicked(index));
        }

        openButton.onClick.AddListener(OnOpenClicked);
        closeButton.onClick.AddListener(OnCloseClicked);
        gameObject.SetActive(false);
        UpdateImages();
    }

    public void UpdateImages()
    {
        List<Supply> suppllies = Inventory.Instance.GetSupplies();

        for(int i = 0; i < suppllies.Count; i++)
        {
            inventoryImages[i].sprite = suppllies[i].GetImage();
            inventoryImages[i].color = Color.white;
        }
    }

    void OnSupplyClicked(int index)
    {

    }

    void OnOpenClicked()
    {
        gameObject.SetActive(true);
    }

    void OnCloseClicked()
    {
        gameObject.SetActive(false);
    }

}
