using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Action currentAction;
    public string prevScene;
    public string nextScene;

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
    
    public void TriggerEnemyEncounter()
    {
        SetPrevScene();

        LoadActionScene("EnemyEncounter");
    }

    public void LoadActionScene(string actionName)
    {
        SetPrevScene();
        string currScene = SceneManager.GetActiveScene().name;
        string encounterScene = currScene.Substring(0, currScene.IndexOf('_') + 1) + actionName;
        SceneManager.LoadScene(encounterScene);
    }

    public void LoadPrevScene()
    {
        SceneManager.LoadScene(prevScene);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void SetPrevScene()
    {
        prevScene = SceneManager.GetActiveScene().name;
    }

    public void SetNextScene()
    {
        int currSceneIndex = SceneManager.GetActiveScene().buildIndex;
        nextScene = SceneManager.GetSceneByBuildIndex(++currSceneIndex).name;
    }

}
