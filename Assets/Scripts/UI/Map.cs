using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    public Sprite monster;
    public Sprite blank;
    public List<Image> spaces;
    public Image gameOverSpace;
    float timer = 0.0f;
    float timerDefault = 3.0f;
    int monsterSpace = 0;
    bool gameOver = false;

    private void Start()
    {
        timer = timerDefault;
        spaces[0].sprite = monster;
    }

    private void Update()
    {
        if(!gameOver)
        {
            timer -= Time.deltaTime;

            if(timer < 0.0f)
            {
                MoveForward();
                timer = timerDefault;
            }
        }
    }

    void MoveForward()
    {
        monsterSpace++;

        if(monsterSpace < spaces.Count)
        {
            spaces[monsterSpace].sprite = monster;
            spaces[monsterSpace - 1].sprite = blank;
        }
        else
        {
            spaces[monsterSpace - 1].sprite = blank;
            gameOverSpace.color = Color.white;
            gameOverSpace.sprite = monster;
            gameOver = true;
            Debug.Log("GAME OVERS!!! :))"); ;
        }
        
        
    }

    public void Reset()
    {
        spaces[monsterSpace].sprite = blank;
        spaces[0].sprite = monster;
        monsterSpace = 0;
    }

}
