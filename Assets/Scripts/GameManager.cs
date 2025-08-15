using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Inventory inventory;
    public bool gameOver = false;
    int perception = 0;
    int dayActionsRemaining = 5;
    float playerPosition;
    float monsterPosition;

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

        if(dayActionsRemaining == 0)
        {
            NightFall();
        }
    }


    public void SetPositions(Vector3 player, Vector3 monster)
    {
        playerPosition = player.x;
        monsterPosition = monster.x;
        Debug.Log(playerPosition);
    }

    public float GetPlayer()
    {
        return playerPosition;
    }

    public float GetMonster()
    {
        return monsterPosition;
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

    public void NightFall()
    {
        DialogueController.Instance.SetDialgoue("Night falls...");
    }

}
