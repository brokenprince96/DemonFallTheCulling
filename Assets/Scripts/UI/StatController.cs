using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatController : MonoBehaviour
{
    public static StatController Instance;

    public Button playerButton;
    public Button closeButton;
    public TextMeshProUGUI perception;

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

    public void Start()
    {
        playerButton.onClick.AddListener(OnPlayerClicked);
        closeButton.onClick.AddListener(OnCloseClicked);
        gameObject.SetActive(false);
    }

    public void OnPlayerClicked()
    {
        gameObject.SetActive(true);
        perception.text = GameManager.Instance.GetStat(0).ToString();
    }

    public void OnCloseClicked()
    {
        gameObject.SetActive(false);

    }

}
