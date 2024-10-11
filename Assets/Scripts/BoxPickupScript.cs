using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BoxPickupScript : MonoBehaviour
{
    [SerializeField] private InputInterpreter inputInterpreter;
    [SerializeField] private Transform HoldPosition;
    [SerializeField] private GameObject SelectedBox;
    [SerializeField] private bool HasPickedBox = false;

    [SerializeField] private bool LastInputHandled;
    
    
    void Start()
    {
        GetComponents();
    }
    
    private void GetComponents()
    {
        if (!inputInterpreter) inputInterpreter = GameObject.FindWithTag("Input").GetComponent<InputInterpreter>();
        if (!HoldPosition) HoldPosition = transform.GetChild(0);
    }

    private void Update()
    {
        if (inputInterpreter.InputinteractionRequest && !LastInputHandled)
        {
            InteractWithBox();
            LastInputHandled = true;
        }

        if (!inputInterpreter.InputinteractionRequest)
        {
            LastInputHandled = false;
        }
    }

    private void InteractWithBox()
    {
        if (!SelectedBox) return;
        if (HasPickedBox) DropBox();
        else PickUpBox();
    }
    
    private void DropBox()
    {
        SelectedBox.transform.parent = null;
        SelectedBox.GetComponent<Rigidbody>().isKinematic = false;

        SelectedBox = null;
        HasPickedBox = false;
    }
    
    private void PickUpBox()
    {
        if (!SelectedBox) return;

        SelectedBox.GetComponent<Rigidbody>().isKinematic = true;
        SelectedBox.transform.parent = transform;
        HasPickedBox = true;
        MoveBoxToHoldPosition();
    }

    private void MoveBoxToHoldPosition()
    {
        SelectedBox.transform.DOMove(HoldPosition.position, 0.1f);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.transform.CompareTag("Pickable")) return;
        
        SelectedBox = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.transform.CompareTag("Pickable")) return;
        
        if (SelectedBox) SelectedBox = null;
    }
}
