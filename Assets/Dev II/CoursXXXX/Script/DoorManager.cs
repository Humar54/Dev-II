using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public static DoorManager _instance;
    [SerializeField] private Animator _doorRigth;
    [SerializeField] private Animator _doorLeft;

    private bool _doorIsLocked =true;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void UnlockDoor()
    {
        _doorIsLocked = false;
    }

    public void OpenDoor()
    {
        _doorRigth.SetBool("Open", true);
        _doorLeft.SetBool("Open", true);
    }

    public bool GetDoorIsLockeD()
    {
        return _doorIsLocked;
    }
}
