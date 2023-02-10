
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class List04 : MonoBehaviour
{
    public enum CategoryType
    {
        Closest,
        Fartest,
        Smallest,
        Biggest
    }

    [SerializeField] private List<Transform> _listGameObject = new List<Transform>();
    [SerializeField] private Material _greenMaterial;
    [SerializeField] private Material _redMaterial;
    [SerializeField] private CategoryType _currentCategoryType;
    [SerializeField] private float _nbSpherePerCategory;

    public void ExecuteActionType()
    {
        foreach (Transform sphere in _listGameObject)
        {
            sphere.GetComponent<MeshRenderer>().material = _redMaterial;
        }

        switch (_currentCategoryType)
        {
            case CategoryType.Closest:
                List<Transform> orderedList = _listGameObject.OrderBy(x => (x.transform.position - new Vector3(0, 0, 0)).magnitude).ToList();
                SetGreenColorToList(orderedList);
                break;
            case CategoryType.Fartest:
                List<Transform> orderedList1 = _listGameObject.OrderByDescending(x => (x.transform.position-new Vector3(0,0,0)).magnitude).ToList();
                SetGreenColorToList(orderedList1);
                break;
            case CategoryType.Smallest:
                List<Transform> orderedList2 = _listGameObject.OrderBy(x => x.transform.localScale.x).ToList();
                SetGreenColorToList(orderedList2);
                break;
            case CategoryType.Biggest:
                List<Transform> orderedList3 = _listGameObject.OrderByDescending(x => x.transform.localScale.x).ToList();
                SetGreenColorToList(orderedList3);
                break;
            default:
                break;
        }
    }

    private void SetGreenColorToList(List<Transform> list)
    {
        for (int i = 0; i < _nbSpherePerCategory; i++)
        {
            list[i].GetComponent<MeshRenderer>().material = _greenMaterial;
        }
    }
}
