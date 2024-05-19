using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform playerPaddle;
    public Transform enemyPaddle;

    public BallController ballController;

    public int playerscore = 0;
    public int enemyscore = 0;

    public TextMeshProUGUI textPointsPlayer;
    public TextMeshProUGUI textPointsEnemy;

    public int winPoints;

    public GameObject screenEndGame;

    public TextMeshProUGUI textEndGame;

     void Start()
    {
        ResetGame();
    }
    
    public void ResetGame()
    {
        playerPaddle.position = new Vector3(7f, 0f, 0f);
        enemyPaddle.position = new Vector3(-7f, 0f, 0f);

        ballController.ResetBall();

        playerscore = 0;
        enemyscore = 0;

        textPointsPlayer.text = playerscore.ToString();
        textPointsEnemy.text = enemyscore.ToString();

        screenEndGame.SetActive(false);

    }

    public void ScorePlayer()
    {
        playerscore++;
        textPointsPlayer.text = playerscore.ToString();
        CheckWin();
    }

    public void ScoreEnemy()
    {
        enemyscore++;
        textPointsEnemy.text = enemyscore.ToString();
        CheckWin();
    }

    public void CheckWin()
    {
        if(enemyscore >= winPoints || playerscore >= winPoints)
        {
            //ResetGame() ;
            EndGame();
        }
    }

    public void EndGame()
    {
        screenEndGame.SetActive(true);
        string winner = SaveController.Instance.GetName(playerscore > enemyscore);
        textEndGame.text = "Vitoria " + winner;
        SaveController.Instance.SaveWinner(winner);

        Invoke("LoadMenu", 2f);



    }

    private void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
