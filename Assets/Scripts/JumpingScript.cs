using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingScript : MonoBehaviour
{
    [SerializeField] private InputInterpreter inputInterpreter;
    [Space]
    [SerializeField] private Rigidbody rb;
    [Space]
    [SerializeField] private Transform GrounCheck;
    [SerializeField] private LayerMask GroundMask;
    [Space]
    [SerializeField] private float JumpForce = 5;

    private bool LastInputHandled;
    
    private void Start()
    {
        GetComponents();
    }

    private void GetComponents()
    {
        if (!rb) rb = GetComponent<Rigidbody>();
        if (!inputInterpreter) inputInterpreter = GameObject.FindWithTag("Input").GetComponent<InputInterpreter>();
    }

    private void Update()
    {
        if (inputInterpreter.InputinteractionRequest && !LastInputHandled)
        {
            Jump();
            LastInputHandled = true;
        }

        if (!inputInterpreter.InputinteractionRequest)
        {
            LastInputHandled = false; 
        }
    }

    private void Jump()
    {
        if (!Physics.CheckSphere(GrounCheck.position, 0.4f, GroundMask)) return;
        rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
    }
}
