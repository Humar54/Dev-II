using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Forest : MonoBehaviour
{
    [Header("Customizable Forest Parameter")]
    [Tooltip("La liste des des caractéristiques de chaque arbres à ajouter")]
    [SerializeField] private List<Tree> _treeList = new List<Tree>();
    [SerializeField] private GameObject _treeGamePrefab;
    [Range(0,5)]
    [SerializeField] private float _forestRange;

    private List<GameObject> _treeGOList = new List<GameObject>();

    [Button]
    private void AddTrees()
    {
        foreach (Tree tree in _treeList)
        {
            Vector3 randomPos = new Vector3(UnityEngine.Random.Range(-_forestRange, _forestRange), 0, UnityEngine.Random.Range(-_forestRange, _forestRange));
            _treeGOList.Add(Instantiate(_treeGamePrefab, randomPos, Quaternion.AngleAxis(UnityEngine.Random.Range(0,360),new Vector3(0,1,0))));
            _treeGOList.Last().transform.localScale = new Vector3(tree._radius, tree._height, tree._radius);
        }
    }

    [Button]
    private void OnDestroy()
    {
        foreach (GameObject tree in _treeGOList)
        {
            DestroyImmediate(tree);
        }
        _treeGOList.Clear();
    }

}
