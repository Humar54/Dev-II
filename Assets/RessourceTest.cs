using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourceTest : MonoBehaviour
{
    [Dropdown("GetAllPara")]
    [SerializeField] private string _ressourceType;

    private List<string> GetAllPara()
    {
        return Ressource._allType;
    }
}
