using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkliftMovementParticleScript : MonoBehaviour
{
    [SerializeField] private TankControlMovement movement;
    [SerializeField] private List<ParticleSystem> particles = new List<ParticleSystem>();

    private bool emitting = false;

    private void Update()
    {
        switch (movement.isMoving)
        {
            case true when !emitting:
            {
                foreach (var particle in particles)
                {
                    particle.Play();
                }
                emitting = true;
                break;
            }
            case false when emitting:
            {
                foreach (var particle in particles)
                {
                    particle.Stop();
                }
                emitting = false;
                break;
            }
        }
    }
}
