using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miner : Worker
{
    public override void Work()
    {
        base.Work();
        _manager.AddOre(_production);
    }
}
