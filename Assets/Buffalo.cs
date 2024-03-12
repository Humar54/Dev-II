
using UnityEngine;

public class Buffalo : Animal ,IWorker,IShowName
{
    public void Work()
    {
        Debug.Log("Buffalo is working");
    }

    public string GetName()
    {
        return _name;
    }
}
