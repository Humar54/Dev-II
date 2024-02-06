using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer : Worker
{
    public override void Work()
    {
        base.Work();
        _manager.AddFood(_production);
    }
}
