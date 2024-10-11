using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BarControlScript : MonoBehaviour
{
    public float Progress => Step / MaxStep;
    public float Step;
    public float MaxStep;

    public UnityEvent<float> ProgressChanged;

    public void IncreaseProgress()
    {
        SetProgress(Step + 1);
    }

    public void DecreaseProgress()
    {
        SetProgress(Step - 1);
    }

    private void SetProgress(float value)
    {
        if (value < 0 || value > MaxStep) return;
        Step = value;
        ProgressChanged.Invoke(Progress);
    }

    public void SetStepFromVolume(float volume)
    {
        SetProgress((volume + 80) / 80 * MaxStep);
    }
}
