
using UnityEngine;

public class LockedGate : Gate
{
    private bool _isUnlock;

    private void Start()
    {
        ControlManager._OnToggleLock += SetLockState;
    }

    protected override void OpenDoor()
    {
        if(_isUnlock)
        {
            base.OpenDoor();
        }
    }

    private void SetLockState(bool lockState)
    {
        _isUnlock = lockState;
    }
}
