using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathHandle : MonoBehaviour
{
    public void Restart()
    {
        Debug.Log("Restarting game...");
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadSceneAsync("Main");
    }
}
