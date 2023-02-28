using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tooltips : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _tooltipTxt;

    void Start()
    {
        MouseOverShowTooltip._onMouseOver += UpdateTooltip;
    }

    private void UpdateTooltip(string name)
    {
        _tooltipTxt.text = name;
    }

}
