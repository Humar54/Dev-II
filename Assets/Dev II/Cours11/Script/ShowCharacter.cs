using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.UI;
using TMPro;

public class ShowCharacter : MonoBehaviour
{
    [SerializeField] private List<ScriptableCharacter> _characterList;
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _Pv;
    [SerializeField] private TextMeshProUGUI _Damage;
    [SerializeField] private float _speed;

    private int _characterIndex;


    private void Start()
    {
       
    }
    [Button]
    private void GoUp()
    {
        _characterIndex++;
        if (_characterIndex >= _characterList.Count)
        {
            _characterIndex = 0;
        }
        UpdateCharacter();
    }

    [Button]
    private void GoDown()
    {
        _characterIndex--;

        if (_characterIndex <= 0)
        {
            _characterIndex = _characterList.Count;
        }
        UpdateCharacter();
    }

    private void UpdateCharacter()
    {
        _image.rectTransform.position = _characterList[_characterIndex]._position;
        _image.sprite = _characterList[_characterIndex]._sprite;
        _Pv.text = "PV: " + _characterList[_characterIndex]._HitPoint.ToString();
        _Damage.text = "Damage: " + _characterList[_characterIndex]._damage.ToString();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _image.rectTransform.position += Vector3.right * _speed * Time.deltaTime;

        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            _image.rectTransform.position += Vector3.right * -_speed * Time.deltaTime;
        }


        if (Input.GetKey(KeyCode.UpArrow))
        {
            _image.rectTransform.position += Vector3.up * _speed * Time.deltaTime;

        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            _image.rectTransform.position += Vector3.down * _speed * Time.deltaTime;
        }
        _characterList[_characterIndex]._position = _image.rectTransform.position;
    }
    [Button]
    public void IncreaseCharacterDamage()
    {
        _characterList[_characterIndex]._damage++;
        UpdateCharacter();
    }
}
