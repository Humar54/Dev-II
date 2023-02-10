
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private int _value;

    private void Start()
    {
        Detector._triggerEnter += IncrementCounter;
    }

    private void IncrementCounter()
    {
        _value++;
        _text.text = _value.ToString();
    }
}
