using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    public Text winText;
    
    
    
    
    void Start()
    {
        Time.timeScale = 1.0f;
        score = 0;
       
        
        winText.gameObject.SetActive(false);
        
    }

   

    private void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
        
    }

    public void AddScore(int points)
    {
        score += points;
        
        if (score >= 30)
        {
            EndGame();
        }
    }

   

    private void Update()
    {
        UpdateScore();
    }

    public void EndGame()
    {
        winText.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
    }
    
    
}