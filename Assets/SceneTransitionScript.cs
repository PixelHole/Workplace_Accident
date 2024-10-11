using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SceneTransitionScript : MonoBehaviour
{
    [SerializeField] private Image BlackScreen;
    [SerializeField] public float TransitionTime;
    

    public void FadeToBlack()
    {
        BlackScreen.DOColor(new Color(22, 23, 26, 255), TransitionTime);
    }

    public void FadeToTransparent()
    {
        BlackScreen.DOColor(new Color(22, 23, 26, 0), TransitionTime);
    }
}
