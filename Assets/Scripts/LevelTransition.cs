using UnityEngine;
using UnityEngine.SceneManagement; 

public class LevelTransition : MonoBehaviour
{
    public string nextSceneName; // Nombre de la escena a cargar

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto que entra en el trigger tiene la etiqueta "Player"
        if (collision.CompareTag("Player"))
        {
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        // Carga la escena especificada en nextSceneName
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
