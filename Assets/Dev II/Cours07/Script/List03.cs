
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class List03 : MonoBehaviour
{
    [SerializeField] private List<GameObject> _listGameObject = new List<GameObject>();
    [SerializeField] private float _spaceBtwObject = 2f;

    private void Start()
    {
        List<GameObject> orderedList = _listGameObject.OrderBy(x => x.transform.localScale.x).ToList();

        for (int i = 0; i < orderedList.Count; i++)
        {
            orderedList[i].transform.position = new Vector3(1, 0, 0) * i * _spaceBtwObject;
        }
    }
}
