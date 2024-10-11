using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ProgressBarScript : MonoBehaviour
{
    [SerializeField] private GameObject BarObject;
    [SerializeField] private MeshRenderer BarRenderer;
    [SerializeField] private BarControlScript ControlScript;
    [SerializeField] private float MaxLength;
    
    private void Awake()
    {
        GetComponents();
    }

    private void GetComponents()
    {
        if (!BarObject) BarObject = transform.GetChild(0).gameObject;
        if (!BarRenderer) BarRenderer = BarObject.GetComponent<MeshRenderer>();
        if (!ControlScript) ControlScript = transform.parent.GetComponent<BarControlScript>();
        ControlScript.ProgressChanged.AddListener(UpdateBarLength);
    }

    private void UpdateBarLength(float step)
    {
        if (step == 0)
        {
            BarRenderer.enabled = false;
            return;
        }
        BarRenderer.enabled = true;
        
        transform.localScale = new Vector3(1, 1, GetZScaleFromStep());
    }

    private float GetZScaleFromStep()
    {
        return ControlScript.Progress * MaxLength;
    }
}
