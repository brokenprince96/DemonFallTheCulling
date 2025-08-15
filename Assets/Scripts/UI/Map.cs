using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    public RectTransform player;
    public RectTransform monster;
    public float playerXDefault;
    public float monsterXDefault;
    public Image gameOverSpace;
    float monsterMoveSpeed = 8.0f;
    float playerMoveSpeed = 20.0f;

    private void Start()
    {
        if(GameManager.Instance.GetPlayer() > 0.0f)
            Debug.Log(GameManager.Instance.GetPlayer());
    }

    private void Update()
    {
        if(!GameManager.Instance.gameOver)
        {
            if(monster.position.x > player.position.x)
            {
                DialogueController.Instance.SetDialgoue("You have been overtaken by the monster wave...");
                GameManager.Instance.gameOver = true;
            }
            else
            {
                monster.Translate(Vector3.right * Time.deltaTime * monsterMoveSpeed);
            }
        }
    }

    public void MoveForward()
    {
        GameManager.Instance.SetPositions(player.position, monster.position);

        StartCoroutine(MovePlayer(3.0f));
    }

    IEnumerator MovePlayer(float duration)
    {
        float current = 0.0f;
        
        while(current < duration)
        {
            current += Time.deltaTime;
            player.Translate(Vector3.right * Time.deltaTime * playerMoveSpeed);
            yield return null; 
        }
    }

    public void Reset()
    {
        
    }

}
