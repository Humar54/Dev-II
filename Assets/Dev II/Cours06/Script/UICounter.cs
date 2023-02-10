using UnityEngine;
using TMPro;

public class UICounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private int _incrementCounter;

    public void IncrementCounter()
    {
        _incrementCounter++;
        _text.text = _incrementCounter.ToString();
    }
}
