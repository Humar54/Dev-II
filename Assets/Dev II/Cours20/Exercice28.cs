using System.Collections;
using UnityEngine;

public class Exercice28 : MonoBehaviour
{
    [SerializeField] private GameObject _prefab1;
    [SerializeField] private GameObject _prefab2;

    private int _counter;

    private void Start()
    {
        StartCoroutine(MyCoroutine());
    }

    private IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < 100; i++)
        {
            float distance = new Vector3(10, 10, 10).magnitude;
        }
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 50; i++)
        {
            Debug.Log("This is a very important message");
        }
        yield return new WaitForSeconds(1f);
        Factorial(220);
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 50; i++)
        {
            Instantiate(_prefab1);
        }
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 10; i++)
        {
            Instantiate(_prefab2);
        }
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 50; i++)
        {
            if (Physics.Raycast(transform.position, transform.forward, 100))
            {
                _counter++;
            };
        }
    }

    private int Factorial(int value)
    {
        if (value > 1)
        {
            return value * Factorial(value - 1);
        }
        else
        {
            return value;
        }
    }
}
