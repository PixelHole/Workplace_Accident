using UnityEngine;

public class NextLevelDialogScript : MonoBehaviour
{
    private SceneManagement sceneManagement;
    [SerializeField] private string NextLevel;
    
    
    private void Start()
    {
        GetComponents();
    }

    private void GetComponents()
    {
        sceneManagement = GameObject.FindWithTag("SceneManager").GetComponent<SceneManagement>();
    }

    public void LoadNextLevel()
    {
        sceneManagement.LoadNextLevel();
    }

    public void LoadMenu()
    {
        sceneManagement.LoadMainMenu();
    }
}
