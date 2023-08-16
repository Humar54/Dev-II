using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSingleton : MonoBehaviour
{
    public static TestSingleton _instance;
    // Start is called before the first frame update
    private void Awake()
    {
        _instance = this;
    }
    
    public void Test()
    {
        
        Debug.Log(name);
    }

 

}
