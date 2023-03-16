using UnityEngine;

[CreateAssetMenu(fileName ="AssetName", menuName ="ScriptableObjectCategory/ScriptableName")]
public class MyScriptable : ScriptableObject
{
    public string _myString;
    public float _myFloat;
    public int _myInt;
}


public class  AccesScriptableObject: MonoBehaviour
{
    public MyScriptable _myScriptable;

    private void AccessScriptableData()
    {
        Debug.Log(_myScriptable._myString);
    }
}