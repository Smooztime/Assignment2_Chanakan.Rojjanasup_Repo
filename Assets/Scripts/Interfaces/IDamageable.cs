using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    //Interface Segregation
    public void OnGetDamage(PlayerHealth playerHealth);
}
