using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using UnityEngine.UI;
using Unity.AI.Navigation;

public class DoorButtons : MonoBehaviour
{
    [SerializeField] private NavMeshSurface navMeshSurface;
    [SerializeField] private Button _unlockBtn;
    [SerializeField] private Button _OpenBtn;
    [SerializeField] private Button _bridgeBtn;
    [SerializeField] private Door2 _door;
    [SerializeField] private GameObject _bridge;

    [SerializeField] private List<Sprite> _gateBtnImage;
    [SerializeField] private List<Sprite> _lockBtnImage;
    [SerializeField] private List<Sprite> _bridgeBtnImage;


    private void Start()
    {
        _unlockBtn.onClick.AddListener(ToggleLockDoors);
        _OpenBtn.onClick.AddListener(ToggleOpenDoor);
        _bridgeBtn.onClick.AddListener(ToggleBridge);
    }

    public void ToggleLockDoors()
    {
        _door.ToggleLockDoor();
        ToggleButtonDisplay(_unlockBtn, _door.GetDoorIsLockeD(), _lockBtnImage);
    }

    public void ToggleOpenDoor()
    {
        if (_door.GetDoorIsOpen())
        {
            _door.CloseDoor();
        }
        else
        {
            _door.OpenDoor();
        }
        ToggleButtonDisplay(_OpenBtn, _door.GetDoorIsOpen(), _gateBtnImage);
    }

    public void ToggleBridge()
    {

        _bridge.SetActive(!_bridge.activeSelf);
        navMeshSurface.BuildNavMesh();

        ToggleButtonDisplay(_bridgeBtn, _bridge.activeSelf, _bridgeBtnImage);
    }

    private void OnDestroy()
    {
        _unlockBtn.onClick.RemoveAllListeners();
        _OpenBtn.onClick.RemoveAllListeners();
        _bridgeBtn.onClick.RemoveAllListeners();
    }

    private void ToggleButtonDisplay(Button btn, bool isOn, List<Sprite> _OnOffSpriteList)
    {
        btn.image.sprite = isOn ? _OnOffSpriteList[0] : _OnOffSpriteList[1];
    }
}
