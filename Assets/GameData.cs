using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    public static List<float> TimerValues { get; private set; } = new List<float>();

    public static void AddTimerValue(float value)
    {
        TimerValues.Add(value);
        SaveTimerValues();
    }

    public static void SaveTimerValues()
    {
        for (int i = 0; i < TimerValues.Count; i++)
        {
            PlayerPrefs.SetFloat("TimerValue" + i, TimerValues[i]);
        }
        PlayerPrefs.SetInt("TimerValuesCount", TimerValues.Count);
        PlayerPrefs.Save();
    }

    public static void LoadTimerValues()
    {
        TimerValues.Clear();
        int count = PlayerPrefs.GetInt("TimerValuesCount", 0);
        for (int i = 0; i < count; i++)
        {
            TimerValues.Add(PlayerPrefs.GetFloat("TimerValue" + i));
        }
    }

    public static List<string> GetFormattedTimerValues()
    {
        List<string> formattedValues = new List<string>();
        foreach (float value in TimerValues)
        {
            float minutes = Mathf.FloorToInt(value / 60);
            float seconds = Mathf.FloorToInt(value % 60);
            formattedValues.Add(string.Format("{0:00}:{1:00}", minutes, seconds));
        }
        return formattedValues;
    }
}
