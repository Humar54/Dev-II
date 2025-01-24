using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    [SerializeField] private List<Fruits> _fruitList;
    [SerializeField] private float _vitamineCContent;


    public void EatAFruit()
    {
        Debug.Log($"Human has eaten {_fruitList[0].name}");
        _vitamineCContent += _fruitList[0].GetEaten();
        Destroy(_fruitList[0].gameObject);
        _fruitList.RemoveAt(0);
    }

}
