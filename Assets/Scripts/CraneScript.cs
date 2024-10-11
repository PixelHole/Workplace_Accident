using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneScript : MonoBehaviour
{
    [SerializeField] private List<Transform> Anchors = new List<Transform>();
    [SerializeField] private Rigidbody Bridge;
    public bool Active = false;
    public float ReachTolerance = 0.01f;
    public float AnchorStopTime = 2f;
    [SerializeField] private float MovementSpeed = 1;
    private int TargetAnchor = 0;
    private bool CanMove = true;


    private void Update()
    {
        if (!Active) return;
        if (CanMove) MoveTowardsAnchor();
        if (IsAtTarget() && CanMove) StartCoroutine(nameof(OnArriveOnTarget));
    }

    private IEnumerator OnArriveOnTarget()
    {
        CanMove = false;
        yield return new WaitForSeconds(AnchorStopTime);
        IncrementTargetAnchor();
        CanMove = true;
    }
    
    private void MoveTowardsAnchor()
    {
        var direction = (Anchors[TargetAnchor].position - Bridge.position).normalized;
        var movement = direction * MovementSpeed;
        Bridge.velocity = movement;
    }

    private void IncrementTargetAnchor()
    {
        TargetAnchor++;
        if (TargetAnchor >= Anchors.Count) TargetAnchor = 0;
    }

    private bool IsAtTarget()
    {
        return Vector3.Distance(Bridge.transform.position, Anchors[TargetAnchor].position) <= ReachTolerance;
    }

    public void Activate()
    {
        Active = true;
    }

    public void Deactivate()
    {
        Active = false;
    }
}
