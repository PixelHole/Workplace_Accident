using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    [SerializeField] private SceneTransitionScript transitionScript;
    public void LoadLevelOne()
    {
        StartCoroutine(LoadLevel("level one"));
    }
    public void LoadMainMenu()
    {
        StartCoroutine(LoadLevel("Menu"));
    }

    public IEnumerator LoadLevel(string levelName)
    {
        transitionScript.FadeToBlack();
        yield return new WaitForSeconds(transitionScript.TransitionTime);
        SceneManager.LoadScene(levelName);
        transitionScript.FadeToTransparent();
    }
}
