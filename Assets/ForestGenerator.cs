using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;

public class ForestGenerator : MonoBehaviour
{
    public enum Shape
    {
        Square,
        Circle,
    }

    [Tooltip("List of all trees to be instantiated")]
    [SerializeField] private List<Tree> _treeList;
    [SerializeField] private GameObject _treePrefab;
    [SerializeField] private List<GameObject> _allTree;

    [Foldout("Parameters")]
    [Range(1, 10)]
    [Tooltip("Range in which to instantiate Tree")]
    [SerializeField] private float _forestRange = 5;
    
    [Foldout("Parameters")]
    [AllowNesting]
    [SerializeField] private Shape _shape;
    [Foldout("Parameters")]
    [AllowNesting]
    [SerializeField] private Vector3 _offset;


    [Button]
   
    public void AddTree()
    {
        if(_shape==Shape.Square)
        {
            foreach (Tree tree in _treeList)
            {
                Vector3 randomPos = _offset + new Vector3(Random.RandomRange(-_forestRange, _forestRange), 0, Random.RandomRange(-_forestRange, _forestRange));
                Quaternion randomRotation = Quaternion.Euler(new Vector3(0, Random.RandomRange(0, 360), 0));
                GameObject newTree = Instantiate(_treePrefab, randomPos, randomRotation);
                _allTree.Add(newTree);
                newTree.transform.localScale = new Vector3(tree._radius, tree._radius, tree._height);
            }
        }
        if(_shape==Shape.Circle)
        {
            foreach (Tree tree in _treeList)
            {
                Vector3 randomPos = Random.insideUnitSphere*_forestRange;
                 randomPos = _offset + new Vector3(randomPos.x,0f, randomPos.z);
                Quaternion randomRotation = Quaternion.Euler(new Vector3(0, Random.RandomRange(0, 360), 0));
                GameObject newTree = Instantiate(_treePrefab, randomPos, randomRotation);
                _allTree.Add(newTree);
                newTree.transform.localScale = new Vector3(tree._radius, tree._radius, tree._height);
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
}
