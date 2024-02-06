using System;
using UnityEngine;
using UnityEngine.UI;

public class DoorButtonsEvent : MonoBehaviour
{
    public static Action _onDoorUnlock;
    public static Action<bool> _onDoorOpen;

    [SerializeField] private Button _openBtn;
    [SerializeField] private Button _unlockBtn;
    [SerializeField] private Sprite _closeBtnImage;
    [SerializeField] private Sprite _openBtnImage;

    private bool _doorIsOpen;

    private void Awake()
    {
        _openBtn.onClick.AddListener(OpenDoor);
        _unlockBtn.onClick.AddListener(UnlockDoor);
    }

    private void UnlockDoor()
    {
        _onDoorUnlock?.Invoke();
        _unlockBtn.interactable = false;
    }

    private void OpenDoor()
    {
        _doorIsOpen = !_doorIsOpen;
        _onDoorOpen?.Invoke(_doorIsOpen);
        if( _doorIsOpen )
        {
            _openBtn.image.sprite = _openBtnImage;
        }
        else
        {
            _openBtn.image.sprite = _closeBtnImage;
        }
    }
}
