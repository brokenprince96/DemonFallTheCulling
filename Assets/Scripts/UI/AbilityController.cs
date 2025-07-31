using UnityEngine;
using UnityEngine.UI;

public class AbilityController : MonoBehaviour
{
    public Button openButton;
    public Button closeButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        openButton.onClick.AddListener(OnOpenClicked);
        closeButton.onClick.AddListener(OnCloseClicked);
        gameObject.SetActive(false);
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
