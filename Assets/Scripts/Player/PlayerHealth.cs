using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private float currentHealth;
    private float maxHealth;
    private IPlayerDied diedHandler;

    private void Awake()
    {
        maxHealth = GetComponent<PlayerController>().PlayerStatsSo.PlayerHealth;
        diedHandler = GetComponent<IPlayerDied>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
        Debug.Log("Player Health = " + currentHealth);
    }

    public void GetDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Player Health = " + currentHealth);
        if (currentHealth <= 0)
        {
            Debug.Log("You Died!");
            diedHandler?.OnPlayerDied();
            currentHealth = maxHealth;
            Debug.Log("Player Health = " + currentHealth);
        }
    }

    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
            Debug.Log("Health Full");

            Debug.Log("Player Health = " + currentHealth);
        }
    }
}
