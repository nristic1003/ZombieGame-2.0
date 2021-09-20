using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{


    private void Start()
    {
        PlayerPrefs.SetInt("NumOfBullets", 10);
        PlayerPrefs.SetInt("CurrentScore", 0);
        PlayerPrefs.SetInt("NumOfCoins", 0);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }


    public void Quit()
    {
        Application.Quit();
    }
}
