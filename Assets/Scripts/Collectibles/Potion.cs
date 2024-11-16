using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour, IPotionCollectible
{
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
