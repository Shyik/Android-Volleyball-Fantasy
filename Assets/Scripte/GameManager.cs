using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameOverScreen GameOverScreen;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);   
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public bool gameHasEnded = false;

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void GameOver()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            GameOverScreen.Setup();
        }
    }

    public void CompleteLevel()
    {
        Debug.Log("CompleteLevel");
    }
}
