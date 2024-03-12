
using UnityEngine;

public class Duck : Animal, IShowName
{
    public string GetName()
    {
        return _name;
    }

}
