using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ZoneTool : MonoBehaviour
{
    [SerializeField] private List<List<Vector3>> _listOfPointsList = new();
    private List<Vector3> _currentList;
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

    public void AddPointToZone(Vector3 Pos)
    {

        Vector3 positionToAdd = Pos;
        foreach (Vector3 point in _currentList)
        {
            if ((point - Pos).magnitude <= _collapsePointRange)
            {
                positionToAdd = point;
                break;
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
