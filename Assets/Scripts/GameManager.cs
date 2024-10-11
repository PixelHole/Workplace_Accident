using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameObject instance;
    
    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = gameObject;
        }
        
        DontDestroyOnLoad(gameObject);
    }

    private void DestroyDuplicates()
    {
        foreach (var manager in GameObject.FindGameObjectsWithTag("GameManager"))
        {
            
        }
    }

    public void Print(string msg)
    {
        Debug.Log(msg);
    }
}
