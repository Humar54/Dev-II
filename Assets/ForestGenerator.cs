using NaughtyAttributes;
using System.Collections.Generic;

using UnityEngine;

public class ForestGenerator : MonoBehaviour
{

    [Dropdown("GetVectorValues")]
    public Vector3 vectorValue;

    private DropdownList<Vector3> GetVectorValues()
    {
        return new DropdownList<Vector3>()
        {
            { "Left",    Vector3.left },
            { "Up",      Vector3.up },
            { "Down",    Vector3.down },
            { "Forward", Vector3.forward },
            { "Back",    Vector3.back }
        };
    }
    public enum Shape
    {
        None,
        Rectangular,
        Circle,
    }

    [SerializeField] private int _numberOfTreeToInstantiate;

    [Tooltip("List of all trees to be instantiated")]
    [SerializeField] private List<Tree> _treeList;
    [SerializeField] private GameObject _treePrefab;
    [SerializeField] private List<GameObject> _allTree;

    
    [Foldout("Parameters")]

    [SerializeField] private Shape _shape;


    [Foldout("Parameters")]
    [Tooltip("Radius in which to instantiate Tree")]
    [ShowIf(nameof(IsCircle))]
    [SerializeField] private float _radius = 5;


    [Foldout("Parameters")]
    [Tooltip("Rectangular zone in which to place a Tree")]
    [ShowIf(nameof(IsRectangular))]
    [SerializeField] private Vector2 _rectangleSize = new Vector2(1f,1f);


    [Foldout("Parameters")]
    [SerializeField] private Vector3 _offset;



    private bool IsCircle()      => (_shape == Shape.Circle);
    private bool IsRectangular() => (_shape == Shape.Rectangular);

    [Button]
   
    public void AddTree()
    {
        if(_shape==Shape.Rectangular)
        {
            for (int i = 0; i < _numberOfTreeToInstantiate; i++)
            {
                Vector3 randomPos = _offset + new Vector3(Random.RandomRange(-_rectangleSize.x/2f, _rectangleSize.x/2f), 0, Random.RandomRange(-_rectangleSize.y / 2f, _rectangleSize.y / 2f));
                Quaternion randomRotation = Quaternion.Euler(new Vector3(0, Random.RandomRange(0, 360), 0));
                GameObject newTree = Instantiate(_treePrefab, randomPos, randomRotation);
                _allTree.Add(newTree);

                Tree currentTreeType = _treeList[Random.Range(0, _treeList.Count)];
                newTree.transform.localScale = new Vector3(currentTreeType._radius, currentTreeType._height, currentTreeType._radius);
            }

        }
        if(_shape==Shape.Circle)
        {
            foreach (Tree tree in _treeList)
            {
                Vector3 randomPos = Random.insideUnitCircle*_radius;
                 randomPos = _offset + new Vector3(randomPos.x,0f,randomPos.y);
                Quaternion randomRotation = Quaternion.Euler(new Vector3(0, Random.RandomRange(0, 360), 0));
                GameObject newTree = Instantiate(_treePrefab, randomPos, randomRotation);
                _allTree.Add(newTree);
                Tree currentTreeType = _treeList[Random.Range(0, _treeList.Count)];
                newTree.transform.localScale = new Vector3(currentTreeType._radius, currentTreeType._height, currentTreeType._radius);
            }
        }

    }
    [Button]
    public void RemoveAll()
    {
        for (int i = _allTree.Count - 1; i >= 0; i--)
        {
            DestroyImmediate(_allTree[i]);
            _allTree.RemoveAt(i);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (_shape == Shape.Rectangular)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube( _offset, new Vector3(_rectangleSize.x,1f,_rectangleSize.y));
        }

        if(_shape == Shape.Circle)
        {

            Gizmos.color = Color.red;
            DrawCircle(_offset, _radius, 64);
        }




    }

    private void DrawCircle(Vector3 center, float radius, int segments)
    {
        float angleStep = 360f / segments;
        Vector3 prevPoint = center + new Vector3(Mathf.Cos(0f), 0f, Mathf.Sin(0f)) * radius;

        for (int i = 1; i <= segments; i++)
        {
            float angle = angleStep * i * Mathf.Deg2Rad;
            Vector3 nextPoint = center + new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle)) * radius;

            Gizmos.DrawLine(prevPoint, nextPoint);
            prevPoint = nextPoint;
        }
    }

}
