using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;

    public static GameController gameManager;

    [SerializeField]
    private Text scoreText;
    private int enemiesKilled = 0;
    [SerializeField]
    private Text numOfCoins, numOfBullets, playerHealth, pausePanelText;
    private int coins = 0;
    private int bullets;

    private int health = 100;



     void Awake()
    {
        if (!gameManager) gameManager = this;


    }

    public void PauseTheGame()
    {
        Time.timeScale = 0f;
        pausePanelText.text = "Pause";
        pausePanel.SetActive(true);
    } 
    public void ContinueTheGmae()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }
    public void RestartTheGame()
    {
        Time.timeScale = 1;
      
        SceneManager.LoadScene("SampleScene");
        pausePanel.SetActive(false);

    }
    public void ToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        pausePanelText.text = "Game Over";
        pausePanel.SetActive(true);
    }

    public void setScore(int count)
    {
        enemiesKilled += count;
        scoreText.text = "Score: " + enemiesKilled;
    }

    public void increaseCoins(int num)
    {
        coins += num;
        numOfCoins.text = "" + coins;
    }

    public void setNUmOfBullets(int num)
    {
        bullets = num;
        numOfBullets.text = "x " + bullets;
    }


    public void setHealth(int num)
    {
        health = num;
        playerHealth.text = ""+ health + "%";
    }

    public void jump()
    {
        GameObject.Find("Player").GetComponent<PlayerWalk>().checkJumping();
    }


}
