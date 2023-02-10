using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumerationList : MonoBehaviour
{
    [SerializeField] private List<Fruits> _fruitList= new List<Fruits>();
    private enum Fruits
    {
        apple,
        cherry,
        pear,
    }

    private void Start()
    {
        CountEachFruit();
    }

    private void CountEachFruit()
    {
        int appleCount = 0;
        int cherryCount = 0;
        int pearCount = 0;

        foreach (Fruits fruit in _fruitList)
        {
            switch (fruit)
            {
                case Fruits.apple:
                    appleCount++;
                    break;
                case Fruits.cherry:
                    cherryCount++;
                    break;
                case Fruits.pear:
                    pearCount++;
                    break;
                default:
                    break;
            }
        }

        Debug.Log($"Apple count : {appleCount} Cherry count : {cherryCount} Pear count : {pearCount}");
    }
}
