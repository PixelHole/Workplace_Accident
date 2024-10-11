using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class TankControlMovement : MonoBehaviour
{
    [SerializeField] private InputInterpreter inputInterpreter;
    [Space]
    [SerializeField] private Rigidbody rb;
    [Space]
    [SerializeField] private float MovementSpeed = 5;

    [SerializeField] private float RotationSpeed = 0.2f;

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
        HandleMovement();

        if (inputInterpreter.InputRotationDirection == 1)
        {
            RotateRight();
        }
        else if (inputInterpreter.InputRotationDirection == -1)
        {
            RotateLeft();
        }
    }

    public void HandleMovement()
    {
        var direction = transform.forward;
        var movement = direction * (MovementSpeed * inputInterpreter.InputMovementDirection);
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
    }

    public void RotateLeft()
    {
        Rotate(-RotationSpeed);
    }

    public void RotateRight()
    {
        Rotate(RotationSpeed);
    }

    public void Rotate(float amount)
    {
        transform.Rotate(transform.up, amount);
    }
}
