
using NaughtyAttributes;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class UpdateNavMesh : MonoBehaviour
{
    [SerializeField] private NavMeshSurface _navMesh;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //com.unity.ai.navigation
        _navMesh.BuildNavMesh();
    }
    [Button]
    public void UpdateNavMeshF()
    {


    }


    [Button]
    public void ClearNavMeshF()
    {

 
    }
}
