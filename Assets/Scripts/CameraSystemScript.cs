using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystemScript : MonoBehaviour
{
    [SerializeField] private Transform AnchorsParent;
    [SerializeField] private Transform Camera;
    [SerializeField] private int TargetAnchorIndex;
    public float TransitionTime;


    private void Start()
    {
        GetComponents();
    }

    private void GetComponents()
    {
        if (!AnchorsParent) AnchorsParent = transform.GetChild(0);
        if (!Camera) Camera = transform.GetChild(1);
    }
    
    private void Update()
    {
        MoveCameraToTargetAnchor();
    }

    public void SetTargetAnchorIndex(string index) => SetTargetAnchorIndex(int.Parse(index));

    public void SetTargetAnchorIndex(int index)
    {
        if (index < 0 || index >= AnchorsParent.childCount) return;
        TargetAnchorIndex = index;
    }

    private void MoveCameraToTargetAnchor()
    {
        Camera.localPosition = Vector3.Slerp(Camera.localPosition, AnchorsParent.GetChild(TargetAnchorIndex).localPosition,
            TransitionTime);
    }
}
