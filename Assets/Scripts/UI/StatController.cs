using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatController : MonoBehaviour
{
    public Button playerButton;
    public Button closeButton;
    public TextMeshProUGUI perception;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        playerButton.onClick.AddListener(OnPlayerClicked);
        closeButton.onClick.AddListener(OnCloseClicked);
        gameObject.SetActive(false);
    }

    public void OnPlayerClicked()
    {
        gameObject.SetActive(true);

    }

    public void OnCloseClicked()
    {
        gameObject.SetActive(false);

    }

}
