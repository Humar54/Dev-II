using System;
using UnityEngine;

public class ScriptWithEvent : MonoBehaviour
{
    public Action<int> _onEvent;
}
