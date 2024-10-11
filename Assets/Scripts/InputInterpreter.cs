using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class InputInterpreter : MonoBehaviour
{
    private SceneManagement sceneManagement;
    
    public byte InputMovementDirection;
    public int InputRotationDirection;
    public bool InputinteractionRequest;


    private void Awake()
    {
        GetComponents();
    }

    private void GetComponents()
    {
        sceneManagement = GameObject.FindWithTag("SceneManager").GetComponent<SceneManagement>();
    }

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

    public void RequestRestartScene()
    {
        sceneManagement.RestartLevel();
    }
}
