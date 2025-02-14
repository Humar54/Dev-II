using UnityEngine;

public class Door2 : MonoBehaviour
{

    [SerializeField] private Animator _doorRigth;
    [SerializeField] private Animator _doorLeft;

    private bool _doorIsLocked =true;
    private bool _isOpen;

    private void Awake()
    {

    }

    public void ToggleLockDoor()
    {
        _doorIsLocked =!_doorIsLocked;
    }

    public void OpenDoor()
    {
        if (_doorIsLocked)
        {
            _isOpen = true;
            _doorRigth.SetBool("Open", true);
            _doorLeft.SetBool("Open", true);
        }
    }

    public void CloseDoor()
    {
        _isOpen=false;
        _doorRigth.SetBool("Open", false);
        _doorLeft.SetBool("Open", false);
    }
    public bool GetDoorIsLockeD()
    {
        return _doorIsLocked;
    }

    public bool GetDoorIsOpen()
    {
        return _isOpen;
    }
}
