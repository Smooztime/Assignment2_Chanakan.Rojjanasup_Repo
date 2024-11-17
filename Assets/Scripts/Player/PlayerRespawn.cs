using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour, IRespawnable
{
    //This script used Single Responsibility about Respawn Only
    //And this script used IRespawnable make Playerhealth can check when player died, the script will use this
    private PlayerController controller;
    private PlayerHealth health;

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        health = GetComponent<PlayerHealth>();
    }

    public void Respawn()
    {
        StartCoroutine(SetPlayerRespawn());
    }
    private IEnumerator SetPlayerRespawn()
    {
        controller.RB.velocity = Vector3.zero;
        controller.ControllerActive(false);
        yield return new WaitForSeconds(3);
        transform.position = controller.StartPos;
        controller.ControllerActive(true);
        health.Heal(controller.PlayerStatsSo.PlayerHealth);
    }
}
