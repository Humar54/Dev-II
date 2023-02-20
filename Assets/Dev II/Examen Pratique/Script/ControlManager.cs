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

    private void Awake()//2pts
    {
        //Utiliser un Singleton Pattern pour le Control Manager
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

    public void ToggleDoorButton()//2pts
    {
        _isDoorOpen = !_isDoorOpen;
        if (_isDoorOpen)
        {
            _OnGateOpen?.Invoke();
        }
        else
        {
            _OnGateClose?.Invoke();
        }
        // Inverser la valeur de _isDoorOpen
        //si la porte doit être ouverte appeler l'évènement _OnGateOpen et à l'inverse l'évènement _OnGateClose
        ToggleButtonDisplay(_toggleGateBtn, _isDoorOpen, _gateBtnImage);
    }

    public void ToggleLockButton()//1pts
    {
        _isUnlocked = !_isUnlocked;
        _OnToggleLock?.Invoke(_isUnlocked);
        // Inverser la valeur de _isUnlocked
        // Appeler l'évènement qui barre ou débarre les portes
        ToggleButtonDisplay(_toggleLockBtn, _isUnlocked, _lockBtnImage);
    }

    public void ToggleLight()//2pts
    {
        _isLightOn = !_isLightOn;
        _lightTimer = 0;
        _currentLightIntensity = _light.intensity;
        // Inverser la valeur de _isLightOn


        // Mettre le timer de gradation graduel de la lumière à 0;

        // Assigner la valeur de _currentLight Intensity à la valeur d'intensité actuel de la lumière (_light.intensity)
        ToggleButtonDisplay(_toggleLightBtn, _isLightOn, _lightBtnImage);
    }

    public void SpawnSphere()//2pts
    {
        if (_lastSphere != null)
        {
            Destroy(_lastSphere);
        }

        _lastSphere = Instantiate(_sphere, new Vector3(0, 0.5f, 0), Quaternion.identity);

        //Détruire la sphére actuelle si elle existe

        //Instancier une nouvelle sphère au dessus du plan et assigner la valeur de _currentSphere a la sphere nouvellement créée 
    }

    private void Update()//4pts
    {
        _lightTimer += Time.deltaTime;

        if (_isLightOn)
        {
            _light.intensity = Mathf.Lerp(_currentLightIntensity, 4, _lightTimer / _lightChangeDelay);
        }
        else
        {
            _light.intensity = Mathf.Lerp(_currentLightIntensity, 0, _lightTimer / _lightChangeDelay);
        }

        // Incrémenter le lightTimer en fonction du temps qui s'écoule

        // Si la lumière est allumé, interpoler linéairement l'intensité de la lumière vers 1 en fonction du lightTimer et du _lightChangeDelay

        // Si la lumière est fermée, interpoler linéairement l'intensité de la lumière vers 0 en fonction du lightTimer et du _lightChangeDelay
    }

    public void GiveImpulseToSphere()//3pts
    {
        Vector3 RandomDirection = new Vector3(UnityEngine.Random.Range(-1f, 1f), 0, UnityEngine.Random.Range(-1f, 1f)).normalized;
        _lastSphere.GetComponent<Rigidbody>().velocity = _sphereSpeed * RandomDirection;
        // Créer un vecteur direction de taille 1 (normalisé) qui pointe vers une direction orientée au hazard sur le plan XZ

        // Si la currentSphere existe, utiliser la direction déterminée au hazard pour assigné la vitesse au Rigidbody de la sphère (utiliser sphereSpeed) 
    }

    public void AddOneToScore()//1pts
    {
        _score++;
        _scoreTxt.text = _score.ToString();
        //Ajouter 1 au score

        //Mettre a jour la valeur le texte du score dans le UI
    }

    private void ToggleButtonDisplay(Button btn, bool isOn, List<Sprite> _OnOffSpriteList)
    {
        btn.image.sprite = isOn ? _OnOffSpriteList[0] : _OnOffSpriteList[1];
    }
}
