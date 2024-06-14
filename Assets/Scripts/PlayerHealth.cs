using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f; 
    public HeartSystem heartSystem;  

    void Start()
    {
        if (heartSystem == null)
        {
            heartSystem = FindObjectOfType<HeartSystem>();
            if (heartSystem == null)
            {
                Debug.LogError("HeartSystem not found on the scene!");
            }
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        Debug.Log("Health now: " + health + "%");
        heartSystem.TakeDamage(1);  

        if (health <= 0)
        {
            Debug.Log("Player died. Respawning...");
            Respawn();
        }
    }

void Respawn()
{
    CountdownTimer countdownTimer = FindObjectOfType<CountdownTimer>();
    if (countdownTimer != null)
    {
        countdownTimer.StopTimer();
    }
    else
    {
        Debug.LogError("CountdownTimer not found!");
    }

    if (countdownTimer != null)
    {
        countdownTimer.ResetTimer();
    }

    SceneManager.LoadSceneAsync("Main Death");
}

}
