using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour, IDamageable
{
    //This script used Single Responsibility about Respawn Only
    //And this script used IDamageable to make PlayerHealth check if get damage from this
    [SerializeField] private TrapsSO trapsSO;

    private MeshRenderer[] _mesh;
    private Collider _collider;

    private void Awake()
    {
        _mesh = GetComponentsInChildren<MeshRenderer>();
        _collider = GetComponent<Collider>();
    }

    //Used IDamageable interface for add damage to player
    public void OnGetDamage(PlayerHealth playerHealth)
    {
        OnTrap(playerHealth);
    }

    private void OnTrap(PlayerHealth playerHealth)
    {
        playerHealth.GetDamage(trapsSO.damage);
        StartCoroutine(TrapInvisible());
    }

    private IEnumerator TrapInvisible()
    {
        foreach(MeshRenderer mesh in _mesh)
        {
            mesh.enabled = false;
        }
        _collider.enabled = false;
        yield return new WaitForSeconds(trapsSO.invisibleTime);
        foreach (MeshRenderer mesh in _mesh)
        {
            mesh.enabled = true;
        }
        _collider.enabled = true;
    }
}
