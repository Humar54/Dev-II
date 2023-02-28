using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseOverShowTooltip : MonoBehaviour, IPointerEnterHandler
{
    public static event Action<string> _onMouseOver;

    public void OnPointerEnter(PointerEventData eventData)
    {
        _onMouseOver?.Invoke(gameObject.name);
        Debug.Log("test");
    }

    private void OnMouseEnter()
    {
        _onMouseOver?.Invoke(gameObject.name);
    }
}
