using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScores : MonoBehaviour
{
    //Single Responsibility about health
    //Open/Closed
    //Liskov
    [SerializeField] private float maxScore;
    private float currentScore;

    private void Start()
    {
        currentScore = 0;
        Debug.Log("Player Score = " + currentScore);
    }

    //Create a method that other script can used this with closed to fix when collect collectibles
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
