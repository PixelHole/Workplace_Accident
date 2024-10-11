using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private SceneManagement sceneManagement;
    [SerializeField] private AudioClip MenuMusic;
    [SerializeField] private AudioClip LevelMusic;
    [Space]
    [SerializeField] private AudioSource source;

    [SerializeField] private float FadeTime = 1;

    private void Start()
    {
        ConnectEvents();
        source.Play();
        FadeInMusic();
    }

    private void ConnectEvents()
    {
        sceneManagement.OnLoadStart.AddListener(OnSceneEnd);
        sceneManagement.OnLoadEnd.AddListener(OnSceneStart);
    }

    private void OnSceneEnd()
    {
        FadeOutMusic();
    }

    private void OnSceneStart(string name)
    {
        ChangeTrack(name);
        FadeInMusic();
    }

    private void ChangeTrack(string name)
    {
        if (name == "Menu")
        {
            source.clip = MenuMusic;
            return;
        }
        
        source.clip = LevelMusic;
    }
    
    private void FadeOutMusic()
    {
        var tween = source.DOFade(0, FadeTime);
        tween.onComplete += () => source.Stop();
    }
    
    private void FadeInMusic()
    {
        source.Play();
        source.DOFade(1, FadeTime);
    }
}