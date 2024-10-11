using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSettingsMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer MusicMixer;
    [SerializeField] private AudioMixer SFXMixer;

    [SerializeField] private BarControlScript SfxControl;
    [SerializeField] private BarControlScript MusicControl;


    private void Start()
    {
        SetSlidersToVolume();
    }

    public void OnSfxOptionChanged(float newVolume)
    {
        Debug.Log(ProgressToAudioVolume(newVolume));
        SFXMixer.SetFloat("Volume", ProgressToAudioVolume(newVolume));
    }
    
    public void OnMusicOptionChanged(float newVolume)
    {
        MusicMixer.SetFloat("Volume", ProgressToAudioVolume(newVolume));
    }
    
    private void SetSlidersToVolume()
    {
        SFXMixer.GetFloat("Volume", out float sfxVol);
        MusicMixer.GetFloat("Volume", out float musicVol);

        SfxControl.SetStepFromVolume(sfxVol);
        MusicControl.SetStepFromVolume(musicVol);
    }

    private static float ProgressToAudioVolume(float progress)
    {
        return progress * 80 - 80;
    }
}
