using System;

using UnityEngine;
using UnityEngine.Events;

public class Test : MonoBehaviour
{
    public static UnityEvent _onAction =new UnityEvent();
    // Start is called before the first frame update
    void Start()
    {
        _onAction.AddListener(Myfunction);
        _onAction.AddListener(Myfunction);
        _onAction.AddListener(Myfunction);

        _onAction.RemoveListener(Myfunction);
        _onAction?.Invoke();
    }

 

    private void Myfunction()
    {
        Debug.Log("Test");
    }
}
