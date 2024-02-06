
using UnityEngine;

public class DoorManagerEvent : MonoBehaviour
{
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

    public void OpenDoor(bool doorIsOpen)
    {
        if (!_doorIsLocked)
        {
            _doorRigth.SetBool("Open", doorIsOpen);
            _doorLeft.SetBool("Open", doorIsOpen);
        }
    }
}
