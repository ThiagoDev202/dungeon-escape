using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float timeElapsed = 0;
    public bool timerIsRunning = true;
    public TextMeshProUGUI countdownText;

    private void Start()
    {
        timerIsRunning = true;
        GameData.LoadTimerValues(); 
    }

    void Update()
    {
        if (timerIsRunning)
        {
            timeElapsed += Time.deltaTime;
            DisplayTime(timeElapsed);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StopTimer()
    {
        timerIsRunning = false;
        GameData.AddTimerValue(timeElapsed); 
        Debug.Log("Stored Timer values: " + string.Join(", ", GameData.GetFormattedTimerValues()));
    }

    public void ResetTimer()
    {
        timeElapsed = 0;
        timerIsRunning = true;
        DisplayTime(timeElapsed);
    }
}
