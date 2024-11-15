using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatsSO", menuName = "SOs/PlayerStatsSO")]
public class PlayerStatsSo : ScriptableObject
{
    public float playerSpeed;
    public float playerRotationSpeed;
    public float PlayerHealth;
}
