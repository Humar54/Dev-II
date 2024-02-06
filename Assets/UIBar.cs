
using UnityEngine;
using UnityEngine.UI;

public class UIBar : MonoBehaviour
{
    [SerializeField] private Image _bar;

    private int _value;

    private void Start()
    {
        Detector._triggerEnter += IncrementCounter;
    }

    private void IncrementCounter()
    {
        _value+=10;
        
        _bar.rectTransform.sizeDelta = new Vector2(_bar.rectTransform.sizeDelta.x, _value);
    }
}
