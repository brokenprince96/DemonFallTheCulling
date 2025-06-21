using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public Button openButton;
    public Button closeButton;

    public List<Button> supplyButtons; // Assigned via Inspector

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
    }

    private void Update()
    {
        if (gameObject.activeSelf)
            Inventory.Instance.UpdateUI();
    }

    private void OnEnable()
    {
        if (Inventory.Instance != null)
            Inventory.Instance.UpdateUI();
    }

    void OnSupplyClicked(int index)
    {
        Inventory.Instance.UseSupply(index);
        supplyButtons[index].GetComponent<Image>().sprite = null;
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
