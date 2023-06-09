using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;

    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Handle player death if necessary
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Perform actions when the player dies
        // For example, game over screen or respawn logic
    }
}
