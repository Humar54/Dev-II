using System;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public static Action _triggerEnter;

    private void OnTriggerEnter(Collider other)
    {
        _triggerEnter?.Invoke();
    }
}
