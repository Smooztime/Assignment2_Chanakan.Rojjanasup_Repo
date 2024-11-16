using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour, IScoreCollectible
{
    [SerializeField] private CollectiblesSO collectiblesSo;

    public void OnCollect(PlayerScores playerScore)
    {
        GetScore(playerScore);
    }

    private void GetScore(PlayerScores score)
    {
        Destroy(gameObject);
        score.ScoreIncrease(collectiblesSo.amount);
    }
}
