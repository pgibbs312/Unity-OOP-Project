using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Health
{
    private float currentHealth;
    private float maxHealth;
    private float healthRegenerated;
    public Action<float> OnHealthUpdate;

    public Health(float _maxHealth)
    {
        maxHealth = _maxHealth;
    }
    public Health()
    {

    }
    public Health(float _maxHealth, float _healthRegenerated, float _currentHealth = 100f)
    {
        maxHealth = _maxHealth;
        healthRegenerated = _healthRegenerated;
        currentHealth = _currentHealth;
        OnHealthUpdate?.Invoke(currentHealth);
    }
    public void RegenHealth()
    {
        //AddHealth(healthRegenerated * Time.deltaTime);
    }
    public void AddHealth(float value)
    {
        currentHealth = GetHealth();
        Debug.Log($"current health: {currentHealth}, value: {value}");
        // currentHealth = Mathf.Min(currentHealth, currentHealth + value); // give us the maximum value possible
        if (currentHealth + value < maxHealth)
        {
            currentHealth = currentHealth + value; 
        } else {
            currentHealth = maxHealth;
        }
        OnHealthUpdate?.Invoke(currentHealth);
    }
    public void DeductHealth(float value)
    {
        currentHealth = Mathf.Max(0, currentHealth - value);
        OnHealthUpdate?.Invoke(currentHealth);

    }

    public float GetHealth()
    {
        return currentHealth;
    }

}
