using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoxDropSiteScript : MonoBehaviour
{
    public UnityEvent OnBoxEnter;
    public UnityEvent OnBoxExit;

    public bool HasBox;


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Pickable"))
        {
            HasBox = true;
            OnBoxEnter.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Pickable"))
        {
            HasBox = false;
            OnBoxExit.Invoke();
        }
    }
}
