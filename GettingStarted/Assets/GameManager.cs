using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public float restartDelay = 2f;
    private bool isGameOver = false;

    public void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            Debug.Log("Over!");
            Invoke("RestartGame", restartDelay);
        }
    }

    private void RestartGame()
    {
        isGameOver = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void WinGame()
    {
        Debug.Log("Won!!!");
    }
}
