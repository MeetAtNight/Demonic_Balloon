using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    
    public Text timerText;
    private float startTime;
    private bool isPaused = false;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if (!isPaused)
        {
            float t = Time.time - startTime;

            string minutes = Mathf.FloorToInt(t / 60).ToString("00");
            string seconds = Mathf.FloorToInt(t % 60).ToString("00");

            timerText.text = minutes + ":" + seconds;
        }
    }

    public void PauseTimer()
    {
        isPaused = !isPaused;
    }
   

}
