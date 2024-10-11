using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private CameraSystemScript cameraSystem;
    [SerializeField] private List<ParticleSystem> Yippies = new List<ParticleSystem>();
    [SerializeField] private AudioSource EndLevelAudio;
    // must be assigned in editor
    public List<BossScript> Bosses = new List<BossScript>();

    public UnityEvent LevelEnded; 
    
    private void Start()
    {
        ConnectEvents();
    }
    private void ConnectEvents()
    {
        foreach (var boss in Bosses)
        {
            boss.BossDied.AddListener(OnBossDeath);
        }
    }

    private void OnBossDeath(BossScript boss)
    {
        Bosses.Remove(boss);
        CheckFinishCondition();
    }
    private void CheckFinishCondition()
    {
        if (Bosses.Count != 0) return;

        StartCoroutine(nameof(FinishLevel));
    }

    private IEnumerator FinishLevel()
    {
        EnableYippieParticles();
        EndLevelAudio.Play();
        LevelEnded.Invoke();
        yield return new WaitForSeconds(2);
        MoveCamera();
    }

    private void EnableYippieParticles()
    {
        foreach (var yippie in Yippies)
        {
            yippie.Play();
            yippie.GetComponent<AudioSource>().Play();
        }
    }

    private void MoveCamera()
    {
        cameraSystem.SetTargetAnchorIndex(1);
    }
}
