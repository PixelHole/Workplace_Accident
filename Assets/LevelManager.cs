using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject NextLevelDialog;
    [SerializeField] private Transform NextLevelDialogAnchor;
    [SerializeField] private float EndLevelWait;
    [SerializeField] private List<ParticleSystem> Yippies;
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
        
        FinishLevel();
    }

    private void FinishLevel()
    {
        SpawnNextLevelDialog();
        EnableYippieParticles();
        LevelEnded.Invoke();
    }

    private void EnableYippieParticles()
    {
        foreach (var yippie in Yippies)
        {
            yippie.Play();
        }
    }
    private void SpawnNextLevelDialog()
    {
        Instantiate(NextLevelDialog, NextLevelDialogAnchor.position, Quaternion.identity);
    }
}
