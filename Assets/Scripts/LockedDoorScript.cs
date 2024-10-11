using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class LockedDoorScript : MonoBehaviour
{
    [SerializeField] private Transform OpenPosition;
    [SerializeField] private Transform ClosedPosition;

    [SerializeField] private Transform DoorObject;

    [SerializeField] private float TransitionTime;


    public void OpenDoor()
    {
        DoorObject.DOMove(OpenPosition.position, TransitionTime);
    }

    public void ClosedDoor()
    {
        DoorObject.DOMove(ClosedPosition.position, TransitionTime);
    }

    private void CheckForKey(KeyInventoryScript inventory)
    {
        if (inventory.HasBlueKey) OpenDoor();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        CheckForKey(other.GetComponent<KeyInventoryScript>());
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) ClosedDoor();
    }
}
