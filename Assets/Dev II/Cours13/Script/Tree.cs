
using NaughtyAttributes;
using System;


[Serializable]
public class Tree
{
    [MinValue(0.2f), MaxValue(2f)]
    public float _radius;
    [MinValue(0.2f), MaxValue(5f)]
    public float _height;
}
