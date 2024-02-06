using UnityEngine;
using UnityEngine.UI;

public class DoorButtons : MonoBehaviour
{
    [SerializeField] private Button _unlockBtn;
    [SerializeField] private Button _OpenBtn;
    public void UnlockDoors()
    {
        DoorManager._instance.UnlockDoor();
        _unlockBtn.interactable = false;
    }

    public void OpenDoor()
    {
        if(!DoorManager._instance.GetDoorIsLockeD())
        {
            DoorManager._instance.OpenDoor();
            _OpenBtn.interactable = false;
        }
    }
}
