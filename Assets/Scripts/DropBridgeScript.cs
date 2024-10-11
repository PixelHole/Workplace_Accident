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
        Bridge.DORotateQuaternion(Quaternion.Euler(0, 0, 0), DropTime);
    }

    public void DrawBridge()
    {
        Bridge.DORotateQuaternion(Quaternion.Euler(-90, 0, 0), DropTime);
    }
} 
