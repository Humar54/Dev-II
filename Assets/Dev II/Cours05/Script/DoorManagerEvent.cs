using System;
using UnityEngine;

public class DoorManagerEvent : MonoBehaviour
{
    public static Action _OnDoorOpen;
    [SerializeField] private Animator _doorRigth;
    [SerializeField] private Animator _doorLeft;

    private bool _doorIsLocked = true;

    private void Start()
    {
        DoorButtonsEvent._onDoorOpen += OpenDoor;
        DoorButtonsEvent._onDoorUnlock += UnlockDoor;
    }

    public void UnlockDoor()
    {
        _doorIsLocked = false;
    }

    public void OpenDoor()
    {
        if (!_doorIsLocked)
        {
            _doorRigth.SetBool("Open", true);
            _doorLeft.SetBool("Open", true);
            _OnDoorOpen?.Invoke();
        }
    }
}
