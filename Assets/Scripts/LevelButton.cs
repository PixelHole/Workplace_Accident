using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelButton : MonoBehaviour
{
    public UnityEvent Click;
    private void OnMouseDown()
    {
        Debug.Log(transform.name);
        Click.Invoke();
    }
}
