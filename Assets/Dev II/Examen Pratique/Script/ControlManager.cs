using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControlManager : MonoBehaviour
{
    public static Action _OnGateOpen;
    public static Action _OnGateClose;
    public static Action<bool> _OnToggleLock;
    public static ControlManager _instance;

    [SerializeField] private TextMeshProUGUI _scoreTxt;
    [SerializeField] private Button _toggleGateBtn;
    [SerializeField] private Button _toggleLockBtn;
    [SerializeField] private Button _toggleLightBtn;
    [SerializeField] private Button _spawnSphere;
    [SerializeField] private Button _moveSphere;
    [SerializeField] private List<Sprite> _gateBtnImage;
    [SerializeField] private List<Sprite> _lockBtnImage;
    [SerializeField] private List<Sprite> _lightBtnImage;
    [SerializeField] private Light _light;
    [SerializeField] private GameObject _sphere;
    [SerializeField] private float _sphereSpeed = 3f;
    [SerializeField] private float  _lightChangeDelay;

    private GameObject _lastSphere;

    private int _score;
    private float _lightTimer;
    private float _currentLightIntensity;
    private bool _isDoorOpen;
    private bool _isUnlocked;
    private bool _isLightOn;

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
        _toggleGateBtn.onClick.AddListener(ToggleDoorButton);
        _toggleLockBtn.onClick.AddListener(ToggleLockButton); ;
        _toggleLightBtn.onClick.AddListener(ToggleLight);
        _spawnSphere.onClick.AddListener(SpawnSphere); ;
        _moveSphere.onClick.AddListener(GiveImpulseToSphere); ;
    }

    public void ToggleDoorButton()
    {
        _isDoorOpen = !_isDoorOpen;
        if (_isDoorOpen)
        {
            _OnGateOpen?.Invoke();
            _toggleGateBtn.image.sprite = _gateBtnImage[0];
        }
        else
        {
            _OnGateClose?.Invoke();
            _toggleGateBtn.image.sprite = _gateBtnImage[1];
        }
    }

    public void ToggleLockButton()
    {
        _isUnlocked = !_isUnlocked;
        _OnToggleLock?.Invoke(_isUnlocked);

        if (_isUnlocked)
        {
            _toggleLockBtn.image.sprite = _lockBtnImage[0];
        }
        else
        {
            _toggleLockBtn.image.sprite = _lockBtnImage[1];
        }
    }

    public void ToggleLight()
    {
        _isLightOn = !_isLightOn;
        _lightTimer = 0;
        _currentLightIntensity = _light.intensity;
        if (_isLightOn)
        {
            _toggleLightBtn.image.sprite = _lightBtnImage[0];
        }
        else
        {
            _toggleLightBtn.image.sprite = _lightBtnImage[1];
        }
    }

    public void SpawnSphere()
    {
        if (_lastSphere != null)
        {
            Destroy(_lastSphere);
        }

        _lastSphere = Instantiate(_sphere, new Vector3(0, 0.5f, 0), Quaternion.identity);
    }

    private void Update()
    {
        _lightTimer += Time.deltaTime;

        if (_isLightOn)
        {
            _light.intensity = Mathf.Lerp(_currentLightIntensity, 1, _lightTimer / _lightChangeDelay);
        }
        else
        {
            _light.intensity = Mathf.Lerp(_currentLightIntensity, 0, _lightTimer / _lightChangeDelay);
        }
    }

    public void GiveImpulseToSphere()
    {
        Vector3 RandomDirection = new Vector3(UnityEngine.Random.Range(-1f, 1f), 0, UnityEngine.Random.Range(-1f, 1f)).normalized;
        _lastSphere.GetComponent<Rigidbody>().velocity = _sphereSpeed * RandomDirection;
    }

    public void AddOneToScore()
    {
        _score++;
        _scoreTxt.text = _score.ToString();
    }
}
