
using System.Collections.Generic;
using UnityEngine;

public class Liste01 : MonoBehaviour
{
    [SerializeField] private List<GameObject> _listGameObject = new();
    [SerializeField] private GameObject _objectToFind;

    private void Start()
    {
        //Check if s list contains a specific element of the list. (Contains retun a bool) 
        if (_listGameObject.Contains(_objectToFind))
        {
            Debug.Log("The list contains the object we are looking for");
        }
        else
        {
            Debug.Log("The list does not contains the object we are looking for");
        }
    }
}
