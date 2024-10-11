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

    private void LoadNextLevel()
    {
        
    }

    private void LoadMenu()
    {
        sceneManagement.LoadMainMenu();
    }
}
