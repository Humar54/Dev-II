
using UnityEngine;
using TMPro;

public class Calculatrice : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textValue;
    private float _previousNumber;
    private float _currentNumber;
    private Operation _currentOperation;

    public enum Operation
    {
        Addition,
        Substraction,
        Multiplication,
        Division,
        None,
    }

    public void EnterValue(string newValue)
    {
        float test;
        if (float.TryParse(_textValue.text, out test))
        {
            _textValue.text = string.Concat(_textValue.text, newValue);
            _currentNumber = float.Parse(_textValue.text);
        }
        else
        {
            _textValue.text = newValue;
            _currentNumber = float.Parse(_textValue.text);
        }
    }

    public void Add()
    {
        _textValue.text = $"+";
        _currentOperation = Operation.Addition;
        EnterNumber();
    }

    public void Substract()
    {
        _textValue.text = $"-";
        _currentOperation = Operation.Substraction;
        EnterNumber();
    }

    public void Multiply()
    {
        _textValue.text = $"x";
        _currentOperation = Operation.Multiplication;
        EnterNumber();
    }

    public void Divide()
    {
        _textValue.text = $"/";
        _currentOperation = Operation.Division;
        EnterNumber();
    }

    public void Calculate()
    {
        float result = 0;
        switch (_currentOperation)
        {
            case Operation.Addition:
                result = _currentNumber + _previousNumber;
                break;
            case Operation.Substraction:
                result = _previousNumber - _currentNumber;
                break;
            case Operation.Multiplication:
                result = _currentNumber * _previousNumber;
                break;
            case Operation.Division:
                result = _previousNumber / _currentNumber;
                break;
            case Operation.None:
                break;
            default:
                break;
        }
        _previousNumber = result;
        _currentNumber = 0;
        _textValue.text = _previousNumber.ToString();
        _currentOperation = Operation.None;
    }

    public void Clear()
    {
        _currentOperation = Operation.None;
        _previousNumber = 0;
        _currentNumber = 0;
        _textValue.text = "";
    }

    private void EnterNumber()
    {
        if (_previousNumber == 0)
        {
            _previousNumber = _currentNumber;
            _currentNumber = 0;
        }
    }
}
