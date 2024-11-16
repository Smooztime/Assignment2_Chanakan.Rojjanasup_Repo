using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScoreCollectible
{
    public void OnCollect(PlayerScores playerScore);
}
