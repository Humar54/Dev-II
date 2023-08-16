using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBidon : MonoBehaviour
{
    [Button]
    public void CallTestFromOutside()
    {
        TestSingleton._instance.Test();
    }
}
