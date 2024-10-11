using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDropSiteChangeMaterialScript : MonoBehaviour
{
    [SerializeField] private Material DefaultColor;
    [SerializeField] private Material LitColor;

    [SerializeField] private BoxDropSiteScript dropSiteScript;

    [SerializeField] private MeshRenderer renderer;

    private void Start()
    {
        GetComponents();
        dropSiteScript.OnBoxEnter.AddListener(SetColorToLit);
        dropSiteScript.OnBoxExit.AddListener(SetColorToDefault);
    }

    private void GetComponents()
    {
        if (!renderer) renderer = GetComponent<MeshRenderer>();
    }

    private void SetColorToLit()
    {
        renderer.material = LitColor;
    }

    private void SetColorToDefault()
    {
        renderer.material = DefaultColor;
    }
}
