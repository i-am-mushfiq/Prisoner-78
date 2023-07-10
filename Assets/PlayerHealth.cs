using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int totalHealth = 100;
    public TextMeshProUGUI healthText;
    public string gameOverSceneName = "GameOver";

    void Start()
    {
        UpdateHealthText();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collided with enemy!");
            DeductHealth();
        }
    }

    void DeductHealth()
    {
        totalHealth--;

        // Update the health text display
        UpdateHealthText();

        if (totalHealth <= 0)
        {
            // Handle the player's death
            Die();
        }
    }

    void Die()
    {
        // Load the game over scene
        SceneManager.LoadScene(gameOverSceneName);
    }

    void UpdateHealthText()
    {
        // Calculate health percentage
        float healthPercentage = (float)totalHealth / 100f * 100f;

        // Update the text mesh with the health percentage
        healthText.text = "Health: " + healthPercentage.ToString("F0") + "%";
    }
}
