using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Busca el GameOverManager en la escena y activa el Game Over
            FindObjectOfType<GameOverManager>().TriggerGameOver();
        }
    }
}
