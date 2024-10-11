using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ExtendoBridgeScript : MonoBehaviour
{
    [SerializeField] private Transform Bridge;
    [SerializeField] private Transform RestPosition;
    [SerializeField] private Transform ExtendedPosition;
    [SerializeField] private float TransitionTime;


    public void ExtendBridge()
    {
        Bridge.DOLocalMove(ExtendedPosition.localPosition, TransitionTime);
    }

    public void DrawBridge()
    {
        Bridge.DOLocalMove(RestPosition.localPosition, TransitionTime);
    }
}
