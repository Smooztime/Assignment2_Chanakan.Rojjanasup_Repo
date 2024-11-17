using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScoreCollectible
{
    //Interface Segregation
    public void OnCollect(PlayerScores playerScore);
}
