using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class BossScript : MonoBehaviour
{
    private GameManager gameManager;
    
    [SerializeField] private GameObject GoreParticles;
    [SerializeField] private Collider DefaultCollider;
    [SerializeField] private Collider CorpseCollider;
    [SerializeField] private Rigidbody rb;
    
    private bool isAlive = true;

    public UnityEvent<BossScript> BossDied;
    
    public void OnCrushed()
    {
        if (!isAlive) return;
        
        EnableFloppyMode();
        SpawnParticles();
        
        BossDied.Invoke(this);
        isAlive = false;
    }

    private void EnableFloppyMode()
    {
        rb.constraints = RigidbodyConstraints.None;
        DefaultCollider.enabled = false;
        CorpseCollider.enabled = true;
    }
    private void SpawnParticles()
    {
        var particles = Instantiate(GoreParticles, transform.position, Quaternion.identity);
        particles.transform.rotation = Quaternion.AngleAxis(-90, Vector3.right);
    }
}
