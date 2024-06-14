using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI rankingText;
    private const int MAX_RANKING_SIZE = 12;
    void Start()
    {
        Screen.fullScreen = true;
        GameData.LoadTimerValues(); 
        DisplayRanking();
    }

    void DisplayRanking()
    {
        if (rankingText == null)
        {
            Debug.LogError("rankingText is not assigned in the inspector.");
            return;
        }

        List<float> timerValues = GameData.TimerValues; // Acessa diretamente os valores de tempo
        timerValues.Sort(); // Ordena os valores de tempo numericamente do menor para o maior

        if (timerValues.Count > MAX_RANKING_SIZE)
        {
            timerValues.RemoveRange(MAX_RANKING_SIZE, timerValues.Count - MAX_RANKING_SIZE);
        }

        rankingText.text = "Melhores tempos:\n";
        for (int i = 0; i < timerValues.Count; i++)
        {
            float minutes = Mathf.FloorToInt(timerValues[i] / 60);
            float seconds = Mathf.FloorToInt(timerValues[i] % 60);
            rankingText.text += (i + 1) + ". " + string.Format("{0:00}:{1:00}", minutes, seconds) + "\n";
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Main");
    }
}
