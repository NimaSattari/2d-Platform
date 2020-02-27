using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] int PlayerLives = 3;
    [SerializeField] int Score = 0;

    [SerializeField] Text LifeText;
    [SerializeField] Text ScoreText;


    private void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if(numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        LifeText.text = PlayerLives.ToString();
        ScoreText.text = Score.ToString();
    }

    public void AddToScore(int Point)
    {
        Score += Point;
        ScoreText.text = Score.ToString();
    }

    public void ProcessPlayerDeath()
    {
        if(PlayerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    private void TakeLife()
    {
        PlayerLives = PlayerLives - 1;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        LifeText.text = PlayerLives.ToString();
    }

    private void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
