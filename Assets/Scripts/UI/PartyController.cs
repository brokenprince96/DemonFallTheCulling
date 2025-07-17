using UnityEngine;
using UnityEngine.UI;

public class PartyController : MonoBehaviour
{
    public static PartyController Instance;
    public Button partyButton;
    public Button closeButton;
    public Image[] survivorImages;
    int partySize = 0;

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
        partyButton.onClick.AddListener(OnPartyClicked);
        closeButton.onClick.AddListener(OnCloseClicked);
        gameObject.SetActive(false);
    }

    public void OnPartyClicked()
    {
        gameObject.SetActive(true);
    }

    public void OnCloseClicked()
    {
        gameObject.SetActive(false);
    }

    public void AddSurvivor(Sprite sprite)
    {
        //array bounds checked before function call
        survivorImages[partySize].color = Color.white;
        survivorImages[partySize++].sprite = sprite;
    }

}
