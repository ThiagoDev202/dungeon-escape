using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    public GameObject[] hearts;
    public int life;

    void Start()
    {
        life = hearts.Length;  // Inicializa a vida com o número total de corações
        UpdateHeartsUI();
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
        if (life < 0) life = 0;  // Garante que a vida não vá abaixo de zero
        UpdateHeartsUI();
    }

    void UpdateHeartsUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(i < life);  // Ativa o coração se for menor que a vida restante
        }
    }
}
