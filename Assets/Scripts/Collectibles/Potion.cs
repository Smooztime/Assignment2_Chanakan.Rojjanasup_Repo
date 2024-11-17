using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour, IPotionCollectible
{
    //This script used Single Responsibility about Respawn Only
    //And this script used IPotionCollectible to make PlayerHealth check if get heal from this
    [SerializeField] private CollectiblesSO collectiblesSo;
    public void OnCollect(PlayerHealth playerHealth)
    {
        GetScore(playerHealth);
    }

    private void GetScore(PlayerHealth health)
    {
        Destroy(gameObject);
        health.Heal(collectiblesSo.amount);
    }
}
