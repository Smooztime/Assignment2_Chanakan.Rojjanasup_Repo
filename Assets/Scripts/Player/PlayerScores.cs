using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScores : MonoBehaviour
{
    [SerializeField] private float maxScore;
    private float currentScore;

    private void Start()
    {
        currentScore = 0;
        Debug.Log("Player Score = " + currentScore);
    }

    public void ScoreIncrease(float score)
    {
        currentScore += score;
        Debug.Log("Player Score = " + currentScore);

        if (currentScore >= maxScore)
        {
            Debug.Log("You win!");
        }
    }
}
