using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour, IInteractable
{
    [SerializeField] private ISwitchable switchable;

    public void OnInteract()
    {
        if(switchable.IsActive)
        {
            switchable.Deactivate();
        }
        else
        {
            switchable.Activate();
        }
    }
}
