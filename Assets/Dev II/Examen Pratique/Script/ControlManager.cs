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
        //si la porte doit �tre ouverte appeler l'�v�nement _OnGateOpen et � l'inverse l'�v�nement _OnGateClose
        ToggleButtonDisplay(_toggleGateBtn, _isDoorOpen, _gateBtnImage);
    }

    public void ToggleLockButton()//1pts
    {
        _isUnlocked = !_isUnlocked;
        _OnToggleLock?.Invoke(_isUnlocked);
        // Inverser la valeur de _isUnlocked
        // Appeler l'�v�nement qui barre ou d�barre les portes
        ToggleButtonDisplay(_toggleLockBtn, _isUnlocked, _lockBtnImage);
    }

    public void ToggleLight()//2pts
    {
        _isLightOn = !_isLightOn;
        _lightTimer = 0;
        _currentLightIntensity = _light.intensity;
        // Inverser la valeur de _isLightOn


        // Mettre le timer de gradation graduel de la lumi�re � 0;

        // Assigner la valeur de _currentLight Intensity � la valeur d'intensit� actuel de la lumi�re (_light.intensity)
        ToggleButtonDisplay(_toggleLightBtn, _isLightOn, _lightBtnImage);
    }

    public void SpawnSphere()//2pts
    {
        if (_lastSphere != null)
        {
            Destroy(_lastSphere);
        }

        _lastSphere = Instantiate(_sphere, new Vector3(0, 0.5f, 0), Quaternion.identity);

        //D�truire la sph�re actuelle si elle existe

        //Instancier une nouvelle sph�re au dessus du plan et assigner la valeur de _currentSphere a la sphere nouvellement cr��e 
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

        // Incr�menter le lightTimer en fonction du temps qui s'�coule

        // Si la lumi�re est allum�, interpoler lin�airement l'intensit� de la lumi�re vers 1 en fonction du lightTimer et du _lightChangeDelay

        // Si la lumi�re est ferm�e, interpoler lin�airement l'intensit� de la lumi�re vers 0 en fonction du lightTimer et du _lightChangeDelay
    }

    public void GiveImpulseToSphere()//3pts
    {
        Vector3 RandomDirection = new Vector3(UnityEngine.Random.Range(-1f, 1f), 0, UnityEngine.Random.Range(-1f, 1f)).normalized;
        _lastSphere.GetComponent<Rigidbody>().velocity = _sphereSpeed * RandomDirection;
        // Cr�er un vecteur direction de taille 1 (normalis�) qui pointe vers une direction orient�e au hazard sur le plan XZ

        // Si la currentSphere existe, utiliser la direction d�termin�e au hazard pour assign� la vitesse au Rigidbody de la sph�re (utiliser sphereSpeed) 
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
