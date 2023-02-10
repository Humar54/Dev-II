using UnityEngine;

public class CubeEvent : MonoBehaviour
{
    [SerializeField] private UICounter _uiCounter;
    public void IncrementCounter()
    {
        _uiCounter.IncrementCounter();
    }
}
