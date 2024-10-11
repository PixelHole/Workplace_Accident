using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    [SerializeField] private SceneTransitionScript transitionScript;
    public string CurrentLevelName => SceneManager.GetActiveScene().name;
    public UnityEvent OnLoadStart;
    public UnityEvent<string> OnLoadEnd;


    public void LoadNextLevel()
    {
        switch (CurrentLevelName)
        {
            case "Level one":
                LoadLevelTwo();
                break;
            case "Level Two":
                LoadLevelThree();
                break;
            case "Level Three":
                LoadMainMenu();
                break;
        }
    }
    public void LoadLevelOne()
    {
        StartCoroutine(LoadLevel("level one"));
    }
    public void LoadLevelTwo()
    {
        StartCoroutine(LoadLevel("level Two"));
    }
    public void LoadLevelThree()
    {
        StartCoroutine(LoadLevel("level Three"));
    }
    public void LoadMainMenu()
    {
        StartCoroutine(LoadLevel("Menu"));
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
