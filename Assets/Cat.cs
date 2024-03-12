using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Animal, IShowName
{
    public string GetName()
    {
        return _name;
    }

}
