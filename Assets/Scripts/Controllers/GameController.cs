using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel, gameOverPanel;

    public static GameController gameManager;

    [SerializeField]
    private Text scoreText;
    private int enemiesKilled = 0;
    [SerializeField]
    private Text numOfCoins, numOfBullets, playerHealth, pausePanelText;
    private int coins = 0;
    private int bullets;

    private int health = 100;

    public GameObject levelComplete;



     void Awake()
    {
        if (!gameManager) gameManager = this;


    }

    private void Start()
    {
        setScore(PlayerPrefs.GetInt("CurrentScore"));
        increaseCoins(PlayerPrefs.GetInt("NumOfCoins"));
    }


    public void PauseTheGame()
    {
        Time.timeScale = 0f;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        pausePanel.SetActive(false);

    }

    public void FinishTheGame()
    {
        levelComplete.SetActive(true);
    }
    public void ToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void GameOver()
    {
        
        gameOverPanel.SetActive(true);
        GameObject.Find("Pause Button").SetActive(false);
        PlayerPrefs.SetInt("NumOfBullets", 10);
        PlayerPrefs.SetInt("CurrentScore", 0);
        PlayerPrefs.SetInt("NumOfCoins", 0);
        pausePanel.SetActive(false);
    }

    public void setScore(int count)
    {
        enemiesKilled += count;
        PlayerPrefs.SetInt("CurrentScore", enemiesKilled);
        scoreText.text = "Score: " + enemiesKilled;
    }

    public void increaseCoins(int num)
    {
        coins += num;
        PlayerPrefs.SetInt("NumOfCoins", coins);
        numOfCoins.text = "" + coins;
    }

    public void setNUmOfBullets(int num)
    {
        bullets = num;
        PlayerPrefs.SetInt("NumOfBullets", bullets);
        numOfBullets.text = "x " + bullets;
    }


    public void setHealth(int num)
    {
        health = num;

        playerHealth.text = ""+ health + "%";
    }

/*    public void jump()
    {
        GameObject.Find("Player").GetComponent<PlayerMovement>().checkJumping();
    }*/

    public void startClimbing()
    {
        GameObject.Find("Player").GetComponent<LadderMovement>().startClimbing();
    }


}
