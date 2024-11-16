using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    private PlayerScores _playerScores;
    private IInteractable _interactable;

    private void Awake()
    {
        _playerHealth = GetComponent<PlayerHealth>();
        _playerScores = GetComponent<PlayerScores>();
    }

    private void Update()
    {
        Interact();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Collectible collectible))
        {
            collectible.OnCollect(_playerScores);
        }

        if (other.TryGetComponent(out Potion potion))
        {
            potion.OnCollect(_playerHealth);
        }

        if (other.TryGetComponent(out Trap trap))
        {
            trap.OnGetDamage(_playerHealth);
        }

        _interactable = other.GetComponent<IInteractable>();
    }

    private void OnTriggerExit(Collider other)
    {
        _interactable = null;
    }

    private void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E) && _interactable != null)
        {
            _interactable.OnInteract();
        }
    }


}
