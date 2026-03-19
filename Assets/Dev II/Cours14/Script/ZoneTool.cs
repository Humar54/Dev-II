using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ZoneTool : MonoBehaviour
{
    [SerializeField] private List<List<Vector3>> _listOfPointsList = new();
    [SerializeField] private List<Vector3> _currentList;
    [SerializeField] private float _collapsePointRange = 0.5f;
    public int _zoneIndex;

    public void CreateNewZone()
    {
        _currentList = new List<Vector3>();
        _listOfPointsList.Add(_currentList);
        _zoneIndex = _listOfPointsList.Count - 1;
    }


    public void Init()
    {
        //called when initialized.
    }

    //SetDirty signals that something has change in the editor and it will have to be updated in the next OnSceneGUI "Update"
    public void SetDirty()
    {
        EditorUtility.SetDirty(this);
    }

    public void NextZone()
    {
        _zoneIndex++;
        if (_zoneIndex >= _listOfPointsList.Count)
        {
            _zoneIndex = 0;
        }

        _currentList = _listOfPointsList[_zoneIndex];
        SetDirty();
    }
    public int GetCurrentZoneIndex()
    {
        return _zoneIndex;
    }

    public void PrevZone()
    {
        _zoneIndex--;
        if (_zoneIndex < 0)
        {
            _zoneIndex = _listOfPointsList.Count - 1;
        }
        _currentList = _listOfPointsList[_zoneIndex];
        SetDirty();
    }


    public void MoveToClosestIncrement(Vector3 Pos)
    {
        float minDistance =Mathf.Infinity;
        int closerstIndex  =int.MaxValue;
        int index=0;

        foreach (Vector3 item in _currentList)
        {
            float distance= (item - Pos).magnitude;
            if(distance < minDistance)
            {
                minDistance = distance;
                closerstIndex =index;
            }
            index++;
            
        }

        _currentList[closerstIndex] = SnapVector(Pos, 1f);
    }



    public static Vector3 SnapVector(Vector3 v, float increment)
    {
        float Snap(float x) => Mathf.Round(x / increment) * increment;
        return new Vector3(Snap(v.x), Snap(v.y), Snap(v.z));
    }

    public void AddPointToZone(Vector3 Pos)
    {

        Vector3 positionToAdd = Pos;

        if (_currentList.Count>=1)
        {
            float distance = (_currentList[0] - Pos).magnitude;
            

            if(distance <_collapsePointRange)
            {
                Debug.Log("Collaspe"  );
                positionToAdd = _currentList[0];
            }
        }

        _currentList.Add(positionToAdd);
        this.SetDirty();
    }

    public void ClearCurrentZone()
    {
        _listOfPointsList.Remove(_currentList);
        _currentList.Clear();
        SetDirty();
    }

    public List<List<Vector3>> GetAllPointList()
    {
        return _listOfPointsList;
    }
}
