using System;
using UnityEngine;

public class ControlDoor : MonoBehaviour
{
    public Action<bool> _toggleDoor;

    private void OnTriggerEnter(Collider other)
    {
        _toggleDoor?.Invoke(false);
    }
    private void OnTriggerExit(Collider other)
    {
        _toggleDoor?.Invoke(true);
    }
}
