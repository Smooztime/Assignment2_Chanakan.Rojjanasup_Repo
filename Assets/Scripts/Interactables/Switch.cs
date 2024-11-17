using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour, IInteractable
{
    //And this script used IIteractable that when interactor collide with this they can active this script
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
