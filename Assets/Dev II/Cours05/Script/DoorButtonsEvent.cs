using System;
using UnityEngine;
using UnityEngine.UI;

public class DoorButtonsEvent : MonoBehaviour
{
    public static Action _onDoorUnlock;
    public static Action _onDoorOpen;

    [SerializeField] private Button _openBtn;
    [SerializeField] private Button _unlockBtn;

    private void Awake()
    {
        _openBtn.onClick.AddListener(OpenDoor);
        _unlockBtn.onClick.AddListener(UnlockDoor);
        DoorManagerEvent._OnDoorOpen += DisableOpenBtn;
    }

    private void UnlockDoor()
    {
        _onDoorUnlock?.Invoke();
        _unlockBtn.interactable = false;
    }

    private void DisableOpenBtn()
    {
        _openBtn.interactable = false;
    }

    private void OpenDoor()
    {
        _onDoorOpen?.Invoke();
    }
}
