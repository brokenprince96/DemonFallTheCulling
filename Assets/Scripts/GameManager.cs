using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Inventory inventory;
    int perception = 0;

    int dayActionsRemaining = 5;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void LoadEnemyEncounterScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }

    public Inventory GetInventory()
    {
        return inventory;
    }

    public void IncreaseStat(int stat)
    {
        switch(stat)
        {
            case 0:
                perception++;
                break;
        }
    }

    public int GetStat(int stat)
    {
        switch (stat)
        {
            case 0:
                return perception;
        }

        return -1;
    }

    public int GetRemainingDayActions()
    {
        return dayActionsRemaining;
    }

    public void UseDayAction()
    {
        if(dayActionsRemaining > 0)
            dayActionsRemaining--;
    }

}
