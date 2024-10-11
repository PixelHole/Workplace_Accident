using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void Print(string msg)
    {
        Debug.Log(msg);
    }
}
