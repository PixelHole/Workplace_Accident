using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSoundScript : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private TankControlMovement movement;
    [SerializeField] private float VolumeRiseTime = 0.5f;

    [SerializeField] private float VolumeMin = 0.05f;
    [SerializeField] private float VolumeMax = 0.2f;
    [SerializeField] private float PitchMin = 0.6f;
    [SerializeField] private float PitchMax = 0.8f;
    
    private void Update()
    {
        if (movement.isMoving)
        {
            audioSource.volume = Mathf.Lerp(audioSource.volume, VolumeMax, VolumeRiseTime);
            audioSource.pitch = Mathf.Lerp(audioSource.pitch, PitchMax, VolumeRiseTime);
            return;
        }
        audioSource.volume = Mathf.Lerp(audioSource.volume, VolumeMin, VolumeRiseTime);
        audioSource.pitch = Mathf.Lerp(audioSource.pitch, PitchMin, VolumeRiseTime);
    }
}
