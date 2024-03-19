using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;

public class ForestGenerator : MonoBehaviour
{
    [Tooltip("List of all trees to be instantiated")]
    [SerializeField] private List<Tree> _treeList;
    [Range(1, 5)]
    [SerializeField] private float _forestRange = 5;

    [SerializeField] private GameObject _treePrefab;
    [SerializeField] private List<GameObject> _allTree;

    [Button]
    [System.Obsolete]
    public void AddTree()
    {
        foreach (Tree tree in _treeList)
        {
            Vector3 randomPos = new(Random.RandomRange(-_forestRange, _forestRange), 0, Random.RandomRange(-_forestRange, _forestRange));
            Quaternion randomRotation = Quaternion.Euler(new Vector3(0, Random.RandomRange(0, 360), 0));
            GameObject newTree = Instantiate(_treePrefab, randomPos, randomRotation);
            _allTree.Add(newTree);
            newTree.transform.localScale = new Vector3(tree._radius, tree._radius, tree._height);
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
