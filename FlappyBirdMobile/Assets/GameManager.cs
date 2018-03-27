using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public Text ScoreText;
    public GameObject GOUI;
    public bool isGameOver = false;

    public float scrollSpeed = -1.5f;

    public int score = 0;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
            if(instance != null)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(isGameOver&&Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void Scored()
    {
        if (isGameOver)
        {
            return;
        }
        score++;
        ScoreText.text = score.ToString();
    }
    public void PlayerDie()
    {
        //make UI visible
        GOUI.SetActive(true);
        //set boolean
        isGameOver = true;
    }
}
