
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

public class CalculatorWithoutBugs : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textValue;
    [SerializeField] private List<Button> _buttonList;

    private GameObject _gameObject;
    private float _previousNumber;
    private float _currentNumber;
    private int _currentOperation;
    private bool _isCalculationResult;

    private void Start()
    {
        //_buttonList = new List<Button>();

        for (int i = 0; i < _buttonList.Count ; i++)
        {
            int buttonValue = i ;
            _buttonList[buttonValue].onClick.AddListener(delegate { EnterValue(buttonValue.ToString()); });
        }
    }

    private void Update()
    {
        //Debug.Log(_gameObject.name);
    }

    public void Dot()
    {
        EnterValue(".");
    }
        
    public void EnterValue(string newValue)
    {
        if(_isCalculationResult)
        {
            Clear();
        }
        float test;
        if (float.TryParse(_textValue.text, out test))
        {
            _textValue.text = string.Concat(_textValue.text, newValue);
            _currentNumber = float.Parse(_textValue.text);
        }
        else
        {
            if(newValue== ".")
            {
                _textValue.text = "0.";
                _currentNumber = 0;
            }
            else
            {
                _textValue.text = newValue;
                _currentNumber = float.Parse(_textValue.text);
            }

            
        }
        _isCalculationResult = false;
    }

    public void Add()
    {
        _textValue.text = $"+";
        _currentOperation = 1;
        _isCalculationResult = false;
        EnterPreviousNumber();
    }

    public void Substract()
    {
        _textValue.text = $"-";
        _currentOperation = 2;
        _isCalculationResult = false;
        EnterPreviousNumber();
    }

    public void Multiply()
    {
        _textValue.text = $"x";
        _currentOperation = 3;
        _isCalculationResult = false;
        EnterPreviousNumber();
    }

    public void Factorise()
    {
        _textValue.text = $"/";
        _isCalculationResult = false;
        _currentOperation = 4;
        EnterPreviousNumber();
    }

    public void Calculate()
    {
        float result = 0;
        switch (_currentOperation)
        {
            case 1:
                result = _currentNumber + _previousNumber;
                break;
            case 2:
                result = _previousNumber - _currentNumber;
                break;
            case 3:
                result = _currentNumber * _previousNumber;
                break;
            case 4:
                result = _previousNumber / (int)_currentNumber;
                break;
            default:
                break;
        }
        _previousNumber = result;
        _currentNumber = 0;
        _textValue.text = _previousNumber.ToString();
        _currentOperation = 0;
        _isCalculationResult = true;
    }

    public void Clear()
    {
        _currentOperation = 0;
        _previousNumber = 0;
        _currentNumber = 0;
        _textValue.text = "";
    }

    private void EnterPreviousNumber()
    {
        if (_previousNumber == 0)
        {
            _previousNumber = _currentNumber;
            _currentNumber = 0;
        }
    }
}
