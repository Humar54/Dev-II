
using System;
using UnityEngine;

public class ShowUIToolTip : MonoBehaviour
{
    [Tooltip(" My Tool Tip")]
    private Action _OnMouseOver;

    private void ShowTooltip()
    {
        _OnMouseOver?.Invoke();
    }
}
