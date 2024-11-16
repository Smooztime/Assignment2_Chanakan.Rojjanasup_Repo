using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPotionCollectible
{
    public void OnCollect(PlayerHealth playerHealth);
}
