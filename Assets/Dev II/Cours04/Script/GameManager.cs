using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private TextMeshProUGUI _text;
    private int _counter;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void AddCounter()
    {
        _counter++;
        _text.text = _counter.ToString();
    }

    public void RemoveCounter()
    {
        _counter--;
        _text.text = _counter.ToString();
    }
}
