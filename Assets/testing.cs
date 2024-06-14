using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class testing : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Script active on Portal");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered by: " + other.gameObject.name);
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has entered the portal");
            SceneManager.LoadScene("Main Menu");  // Alterado para direcionar diretamente para a cena do menu principal
        }
    }
}
