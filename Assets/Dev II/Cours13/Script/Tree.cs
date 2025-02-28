
using NaughtyAttributes;
using System;
using UnityEngine;

[Serializable]
public class Tree
{
    [AllowNesting]
    [MinValue(2f), MaxValue(10f)]
    public float _lengthOfBranch; 
    [MinValue(0), MaxValue(10)]
    public int _numberOfBranch;
    

    public float _radius;
    public float _height;

 
    public bool _hasLeaf;
    [AllowNesting]
    [ShowIf("_hasLeaf")]

    public float _sizeOfLeaf;
    [AllowNesting]
    [ShowIf("_hasLeaf")]

    public int _numberOfLeaf;
    [AllowNesting]
    [ShowIf("_hasLeaf")]
 
    public Color _colorOfLeaf;


}
