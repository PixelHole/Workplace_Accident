using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(Vector3.up, 0.1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        other.GetComponent<KeyInventoryScript>().GetBlueKey();
        
        Destroy(gameObject);
    }
}
