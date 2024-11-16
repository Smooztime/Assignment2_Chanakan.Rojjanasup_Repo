using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour, IDamageable
{
    [SerializeField] private TrapsSO trapsSO;

    private MeshRenderer[] _mesh;
    private Collider _collider;

    private void Awake()
    {
        _mesh = GetComponentsInChildren<MeshRenderer>();
        _collider = GetComponent<Collider>();
    }

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
