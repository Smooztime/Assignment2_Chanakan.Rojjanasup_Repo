using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPotionCollectible
{
    //Interface Segregation
    public void OnCollect(PlayerHealth playerHealth);
}
