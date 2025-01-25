using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel; 

    private void Start()
    {
        
        gameOverPanel.SetActive(false);
    }

    public void TriggerGameOver()
    {
        
        gameOverPanel.SetActive(true);

        
        Time.timeScale = 0f;
    }

    public void RestartLevel()
    {
        
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }

}
