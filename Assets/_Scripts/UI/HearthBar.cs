using UnityEngine;
using UnityEngine.UI;

public class HearthBar : MonoBehaviour
{
    public Slider _slider;
    public float maxHealth;
    public float currentHealth;
    public GameObject GameOver;
    public float pauseTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        _slider.maxValue = maxHealth;
        _slider.value = maxHealth;
        // Initialize current health
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        _slider.value = currentHealth;

        // Check if health is 0 and activate the GameOver object
        if (currentHealth == 0 && GameOver != null)
        {
            GameOver.SetActive(true);
            // Pause the game
            Invoke(nameof(PauseGame), pauseTime);
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
    }
}