using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class InputInterpreter : MonoBehaviour
{
    public byte InputMovementDirection;
    public int InputRotationDirection;
    public bool InputinteractionRequest;

    public void RequestMoveForward()
    {
        InputMovementDirection = 1;
    }

    public void RequestStopMovement()
    {
        InputMovementDirection = 0;
    }

    public void RequestRotateLeft()
    {
        InputRotationDirection = -1;
    }
    
    public void RequestRotateRight()
    {
        InputRotationDirection = 1;
    }

    public void RequestStopRotation()
    {
        InputRotationDirection = 0;
    }

    public void RequestInteraction()
    {
        InputinteractionRequest = true;
    }

    public void RequestStopInteraction()
    {
        InputinteractionRequest = false;
    }
}
