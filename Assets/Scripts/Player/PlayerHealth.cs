using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    //Single Responsibility about health
    //Open/Closed
    //Liskov
    private float currentHealth;
    private float maxHealth;
    private IRespawnable respawnable;

    public float health => currentHealth;

    private void Awake()
    {
        maxHealth = GetComponent<PlayerController>().PlayerStatsSo.PlayerHealth;
        respawnable = GetComponent<IRespawnable>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
        Debug.Log("Player Health = " + currentHealth);
    }

    //Create a method that other script can used this with closed to fix when get on trap
    public void GetDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Player Health = " + currentHealth);
        if (currentHealth <= 0)
        {
            Debug.Log("You Died!");
            respawnable?.Respawn();
        }
    }

    //Create a method that other script can used this with closed to fix when collect potion
    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
        Debug.Log("Player Health = " + currentHealth);
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
            Debug.Log("Health Full");
            Debug.Log("Player Health = " + currentHealth);
        }
    }
}
