using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 20;  
    private int currentHealth;

    [Header("UI")]
    public Slider healthBar;  
    public Image fillImage;  

    [Header("Health Decay")]
    public float healthDecayRate = 1f; // Cantidad de vida perdida por segundo

    private void Start()
    {
        currentHealth = maxHealth;  
        healthBar.maxValue = maxHealth;  
        healthBar.value = currentHealth;  
        UpdateHealthBarColor();
    }

    private void Update()
    {
        ReduceHealthOverTime();
    }

    private void ReduceHealthOverTime()
    {
        if (currentHealth > 0)
        {
            currentHealth -= Mathf.CeilToInt(healthDecayRate * Time.deltaTime);
            currentHealth = Mathf.Max(0, currentHealth); // Evita que la salud sea negativa
            healthBar.value = currentHealth;  
            UpdateHealthBarColor();

            if (currentHealth <= 0)
            {
                FindObjectOfType<GameOverManager>().TriggerGameOver();
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth;  
        UpdateHealthBarColor();  
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
        healthBar.value = currentHealth;  
        UpdateHealthBarColor();  
    }

    private void UpdateHealthBarColor()
    {
        float healthPercentage = (float)currentHealth / maxHealth;
        Color healthColor = Color.Lerp(Color.red, Color.green, healthPercentage);
        fillImage.color = healthColor;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);  
            if (currentHealth <= 0)
            {
                FindObjectOfType<GameOverManager>().TriggerGameOver();
            }
        }
    }
}
