using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropkeyScript : MonoBehaviour
{
    [SerializeField] private GameObject Key;
    
    
    public void DropKey()
    {
        Instantiate(Key, transform.position, Quaternion.identity);
    }
}
