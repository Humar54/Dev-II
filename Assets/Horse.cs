using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : Animal,IWorker,IShowName
{
    public string GetName()
    {
        return _name;
    }

    public void Work()
    {
        Debug.Log("The horse is working");
    }


}
