using NaughtyAttributes;
using System;
using System.Collections.Generic;

[Serializable]
public class Ressource
{

    [Dropdown("_allType")]
    public string _type;
    public int _value;

    public static List<string> _allType { get { return new List<string>() { "Mineral", "Food" }; } }

}
