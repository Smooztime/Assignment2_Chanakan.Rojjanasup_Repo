using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : ISwitchable
{
    [SerializeField] private GameObject door;
    [SerializeField] private float doorSpeed;
    [SerializeField] private Transform openPosition;

    private bool isActive;
    private Vector3 closePosition;
    public override bool IsActive => isActive;

    private void Start()
    {
        closePosition = door.transform.position;
    }

    public override void Activate()
    {
        isActive = true;
        Debug.Log("Door Active");
    }

    public override void Deactivate()
    {
        isActive = false;
        Debug.Log("door is not active");
    }

    private void Update()
    {
        if(isActive)
        {
            OpenDoor();
        }
        else
        {
            CloseDoor();
        }
    }

    

    private void OpenDoor()
    {
        door.transform.position = Vector3.MoveTowards(door.transform.position, openPosition.position, doorSpeed * Time.deltaTime);
    }

    private void CloseDoor()
    {
        door.transform.position = Vector3.MoveTowards(door.transform.position, closePosition, doorSpeed * Time.deltaTime);
    }
}
