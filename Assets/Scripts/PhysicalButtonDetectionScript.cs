using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalButtonDetectionScript : MonoBehaviour
{
    [SerializeField] private Camera camera;


    private void Start()
    {
        GetComponents();
    }

    private void GetComponents()
    {
        if (!camera) camera = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CastRay();
        }
    }

    private void CastRay()
    {
        if (!Physics.Raycast(camera.ScreenToWorldPoint(Input.mousePosition), transform.forward, out RaycastHit hit,
                1000f))
        {
            return;
        }
        
        if (!hit.transform.CompareTag("Button")) return;

        var btnScript = hit.transform.gameObject.GetComponent<LevelButton>();
        
        btnScript.Click.Invoke();
    }
}
