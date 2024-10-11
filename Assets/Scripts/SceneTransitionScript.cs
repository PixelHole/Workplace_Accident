using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SceneTransitionScript : MonoBehaviour
{
    [SerializeField] private Animator animator;


    private void Start()
    {
        GetComponents();
    }

    private void GetComponents()
    {
        if (!animator) animator = transform.GetChild(0).GetChild(0).GetComponent<Animator>();
    }

    public void FadeToBlack()
    {
        animator.SetBool("Fade", true);
    }

    public void FadeToTransparent()
    {
        animator.SetBool("Fade", false);
    }
}
