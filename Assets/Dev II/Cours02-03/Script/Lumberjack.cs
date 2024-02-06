using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lumberjack : Worker
{
    public override void Work()
    {
        base.Work();
        _manager.AddWood(_production);
    }
}
