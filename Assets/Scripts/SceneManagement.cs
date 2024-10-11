using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    [SerializeField] private SceneTransitionScript transitionScript;
    public string CurrentLevelName => SceneManager.GetActiveScene().name;
    private int LevelIndex = 0;
    public UnityEvent OnLoadStart;
    public UnityEvent<string> OnLoadEnd;


    public void LoadNextLevel()
    {
        switch (LevelIndex)
        {
            case 1:
                LoadLevelTwo();
                break;
            case 2:
                LoadLevelThree();
                break;
            case 3:
                LoadMainMenu();
                break;
        }
    }
    public void LoadLevelOne()
    {
        LevelIndex = 1;
        StartCoroutine(LoadLevel("level one"));
    }
    public void LoadLevelTwo()
    {
        LevelIndex = 2;
        StartCoroutine(LoadLevel("level Two"));
    }
    public void LoadLevelThree()
    {
        LevelIndex = 3;
        StartCoroutine(LoadLevel("level Three"));
    }
    public void LoadMainMenu()
    {
        LevelIndex = 0;
        StartCoroutine(LoadLevel("Menu"));
    }

    public void RestartLevel()
    {
        StartCoroutine(LoadLevel(CurrentLevelName));
    }
    private IEnumerator LoadLevel(string levelName)
    {
        OnLoadStart.Invoke();
        transitionScript.FadeToBlack();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levelName);
        transitionScript.FadeToTransparent();
        OnLoadEnd.Invoke(levelName);
    }
}
