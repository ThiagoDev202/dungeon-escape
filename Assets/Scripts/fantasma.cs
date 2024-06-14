using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fantasma : MonoBehaviour
{
    [SerializeField]
    private Transform alvo;
    [SerializeField]
    private float velocidadeMovimento;
    private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (alvo == null || rigidbody == null)
        {
            Debug.LogError("Componente necessário está ausente!");
            return; // Parar a execução para evitar erros
        }

        Vector2 posicaoAlvo = alvo.position;
        Vector2 posicaoAtual = transform.position;
        Vector2 direcao = posicaoAlvo - posicaoAtual;
        direcao = direcao.normalized;

        rigidbody.velocity = velocidadeMovimento * direcao;

        if (rigidbody.velocity.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (rigidbody.velocity.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(33.3f); // Subtrai 33.3% da vida do jogador
            }
            else
            {
                Debug.LogError("PlayerHealth component not found on Player!");
            }
        }
    }
}
