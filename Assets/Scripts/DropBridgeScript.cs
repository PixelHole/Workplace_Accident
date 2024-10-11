using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DropBridgeScript : MonoBehaviour
{
    [SerializeField] private Transform Bridge;
    [SerializeField] private float DropTime;

    public void ExtendBridge()
    {
        Bridge.DOLocalRotate(new Vector3(0, 0, 0), DropTime);
    }

    public void DrawBridge()
    {
        Bridge.DOLocalRotate(new Vector3(-90, 0, 0), DropTime);
    }
} 
