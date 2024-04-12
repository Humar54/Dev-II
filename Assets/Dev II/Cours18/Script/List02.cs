using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class List02 : MonoBehaviour
{
    [SerializeField] private List<Transform> _listGameObject =new List<Transform>();
    [SerializeField] private float _minSize;
    [SerializeField] private Material _greenMaterial;
    [SerializeField] private Material _redMaterial;


    public void ChangeCondForEachSphere()
    {

        foreach (Transform sphere in _listGameObject)
        {
            sphere.GetComponent<MeshRenderer>().material = _redMaterial;
        }

        List<Transform> newList = new List<Transform>();
        newList = _listGameObject.FindAll(x => x.localScale.x >= _minSize);

        foreach (Transform sphere in newList)
        {
            sphere.GetComponent<MeshRenderer>().material = _greenMaterial;
        }
    }
}
