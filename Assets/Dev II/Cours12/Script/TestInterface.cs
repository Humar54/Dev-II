
using UnityEngine;

public class TestInterface : MonoBehaviour, MyInterface
{
    public bool _myBool
    {
        get;
        private set;
    }

    public float _myFloat
    {
        get;
        private set;
    }

    public int _myInt
    {
        get;
        private set;
    }

    public void MyFunction1()
    {
   
    }

    public bool MyFunction2(float myBool)
    {
        return true;
    }
}
