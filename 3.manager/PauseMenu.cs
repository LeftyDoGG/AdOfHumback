using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    float timeleft = 5.0f;
    public Text text;

    public static bool GamePause = false;
    public GameObject PauseMenuUI;

    public static bool GameFail = false;
    public GameObject GameFailUI;
    public PlayerHealth playerHealth;

    public static bool GameClear = false;
    public GameObject GameWinUI;
    public ScoreManager scoreManager;

    public static bool CountDtoBoss = false;
    public GameObject countDown;


    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (playerHealth.currentHealth <= 0)
        {
            GameFailUI.SetActive(true);
            GameFail = true;
        }


        if (ScoreManager.score == 80)
        {
            GameWinUI.SetActive(true);
            GameClear = true;
        }
        if (ScoreManager.score == 50)
        {
            countDown.SetActive(true);
            timeleft -= Time.deltaTime;
            text.text = "Time Left:" + Mathf.Round(timeleft);
            if (timeleft < 0)
            {
                countDown.SetActive(false);
            }
        }
    
    }

    void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePause = false;

    }
    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePause = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1f;
    }

}
