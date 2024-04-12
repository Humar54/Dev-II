
using System.Collections.Generic;
using UnityEngine;

public class Liste01 : MonoBehaviour
{
    [SerializeField] private List<GameObject> _listGameObject = new List<GameObject>();
    [SerializeField] private GameObject _objectToFind;

    private void Start()
    {
        if(_listGameObject.Contains(_objectToFind))
        {
            Debug.Log("La liste contient l'objet recherché!");
        }
        else
        {
            Debug.Log("La liste ne contien pas l'objet recherché");
        }
    }
}
