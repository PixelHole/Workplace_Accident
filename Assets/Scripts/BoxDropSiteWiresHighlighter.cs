using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDropSiteWiresHighlighter : MonoBehaviour
{
    [SerializeField] private BoxDropSiteScript dropSiteScript;

    private List<MeshRenderer> renderers = new List<MeshRenderer>();

    [SerializeField] private Material LitMaterial;
    [SerializeField] private Material DefaultMaterial;


    private void Start()
    {
        GetRenderers();
        dropSiteScript.OnBoxEnter.AddListener(SetColorToLit);
        dropSiteScript.OnBoxExit.AddListener(SetColorToDefault);
    }

    private void GetRenderers()
    {
        if (transform.childCount == 0) return;
        
        for (int i = 0; i < transform.childCount; i++)
        {
            renderers.Add(transform.GetChild(i).GetComponent<MeshRenderer>());
        }
    }

    private void SetColorToLit()
    {
        foreach (var meshRenderer in renderers)
        {
            meshRenderer.material = LitMaterial;
        }
    }

    private void SetColorToDefault()
    {
        foreach (var meshRenderer in renderers)
        {
            meshRenderer.material = DefaultMaterial;
        }
    }
}
