using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingLetterScript : MonoBehaviour
{
    [SerializeField] private Collider collider;
    [SerializeField] private Rigidbody rb;
    void Start()
    {
        GetComponents();
    }

    private void GetComponents()
    {
        if (!collider) collider = GetComponent<Collider>();
        if (!rb) rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        Debug.Log(transform.name);
        transform.parent = null;
        collider.enabled = true;
        rb.isKinematic = false;
    }
}
