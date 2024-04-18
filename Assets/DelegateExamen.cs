using UnityEngine;

public class DelegateExamen : MonoBehaviour
{
    private delegate int DelegateDeclaration(int x, int y);
    private DelegateDeclaration _myDelegate;
    private int _value = 0;

    private void Start()
    {
        _myDelegate += MyFunction;
        _myDelegate += MyFunction;
        _myDelegate -= MyFunction;

        for (int i = 0; i < 10; i++)
        {
            _value = _myDelegate.Invoke(_value, 0);
        }
    }

    private int MyFunction(int x, int y)
    {
        return x + 1;
    }
}

