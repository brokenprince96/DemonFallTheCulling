using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyController : MonoBehaviour
{
    public static PartyController Instance;
    public Button partyButton;
    public Button closeButton;
    public List<Image> survivorImages;

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
        UpdateImages();
    }

    public void OnPartyClicked()
    {
        gameObject.SetActive(true);
    }

    public void OnCloseClicked()
    {
        gameObject.SetActive(false);
    }

    public void UpdateImages()
    {
        List<Survivor> survivors = Party.Instance.GetPartyMembers();

        for (int i = 0; i < survivors.Count; i++)
        {
            survivorImages[i].sprite = survivors[i].GetImage();
            survivorImages[i].color = Color.white;
        }
    }

}
