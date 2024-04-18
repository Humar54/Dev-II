
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class List03 : MonoBehaviour
{
    [SerializeField] private List<GameObject> _listGameObject = new();
    [SerializeField] private float _spaceBtwObject = 1f;

    private void Start()
    {
        //Order the sphere list by radius (the smaller sphere will be put first)
        List<GameObject> orderedList = _listGameObject.OrderBy(x => x.transform.localScale.x).ToList();

        for (int i = 0; i < orderedList.Count; i++)
        {
            orderedList[i].transform.position = SpherePosition(orderedList, i);
        }
    }
    //Order get the position of the sphere compare to the previous sphere in taking into account the radius in btw the spheres so that
    //the space in between the surface of each sphere is always even
    private Vector3 SpherePosition(List<GameObject> list, int index)
    {
        if (index > 0)
        {
            return new Vector3(1, 0, 0) * (list[index].transform.localScale.x / 2f + list[index - 1].transform.localScale.x / 2f + _spaceBtwObject) + list[index - 1].transform.position;
        }
        return Vector3.zero;
    }
}
