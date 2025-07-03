using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatController : MonoBehaviour
{
    public static StatController Instance;

    public Button playerButton;
    public Button closeButton;
    public TextMeshProUGUI perception;

    Stats stats = new Stats();
    float health = 1.0f;

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        playerButton.onClick.AddListener(OnPlayerClicked);
        closeButton.onClick.AddListener(OnCloseClicked);
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (gameObject.activeSelf)
            UpdateUI();
    }

    public void OnPlayerClicked()
    {
        gameObject.SetActive(true);
    }

    public void OnCloseClicked()
    {
        gameObject.SetActive(false);

    }

    public void UpdateUI()
    {
        perception.text = GetStat(0).ToString();
    }

    public void IncreaseStat(int stat)
    {
        switch (stat)
        {
            case 0:
                stats.perception++;
                break;
            default:
                Debug.LogWarning("stat doesn't exist");
                break;
        }
    }

    public int GetStat(int stat)
    {
        switch (stat)
        {
            case 0:
                return stats.perception;
            default:
                Debug.LogWarning("stat doesn't exist");
                break;
        }

        return -1;
    }

    public float GetHealth()
    {
        return health;
    }

}
