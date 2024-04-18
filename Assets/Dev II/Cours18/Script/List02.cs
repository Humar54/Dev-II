
using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;

public class List02 : MonoBehaviour
{
    [SerializeField] private List<Transform> _listGameObject = new();
    [SerializeField] private float _minSize;
    [SerializeField] private Material _greenMaterial;
    [SerializeField] private Material _redMaterial;

    [Button]
    public void ChangeSphereColor()
    {
        //Turn all the sphere red
        foreach (Transform sphere in _listGameObject)
        {
            sphere.GetComponent<MeshRenderer>().material = _redMaterial;
        }

        // Get all the spheres with a radius greater then _minSize
        List<Transform> listOfSphereWithGreaterRadius = new();
        listOfSphereWithGreaterRadius = _listGameObject.FindAll(x => x.localScale.x >= _minSize);

        //Turn all the sphere in the list green
        foreach (Transform sphere in listOfSphereWithGreaterRadius)
        {
            sphere.GetComponent<MeshRenderer>().material = _greenMaterial;
        }
    }
}
