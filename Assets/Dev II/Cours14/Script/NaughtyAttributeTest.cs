using NaughtyAttributes;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Data 
{
    public int _myInt;
    public bool _myBool;
}




    public class NaughtyAttributeTest : MonoBehaviour
{
    [HorizontalLine(color: EColor.Green)]
    public List<Data> _data;



    [Dropdown("GetVectorValues")]
    public Vector3 vectorValue;

    private DropdownList<Vector3> GetVectorValues()
    {
        return new DropdownList<Vector3>()
        {

            { "Up",      Vector3.up },
            { "Down",    Vector3.down },
            { "Forward", Vector3.forward },
            { "Back",    Vector3.back }
        };
    }





    [Foldout("Mouvement")]
    [SerializeField] private float _maxSpeed;
    [Foldout("Mouvement")]
    [SerializeField] private float _acceleration;
    [Foldout("Mouvement")]
    [SerializeField] private float _rotationSpeed;

    [HorizontalLine(color: EColor.Green)]

    public FireMode fireMode;


    [ShowIf(nameof(IsBurst))]
    [MinValue(2)]
    public int burstCount;

    [ShowIf(nameof(IsAutomatic))]
    [MinValue(0.01f)]
    public float fireRate;

    public int damage;

    private bool IsBurst()
    {
        return fireMode == FireMode.Burst;
    }

    private bool IsAutomatic()
    {
        return fireMode == FireMode.Automatic;
    }

    public enum FireMode
    {
        Single,
        Burst,
        Automatic
    }




    [OnValueChanged(nameof(OnValueChangedCallback))]
    public int _onValueChangeInt;

    private void OnValueChangedCallback()
    {
        Debug.Log("The value has changed and is now: " + _onValueChangeInt);
    }


    }
    /*




    
  



    [HorizontalLine(color: EColor.Green)]
    
 

    [HorizontalLine(color: EColor.Green)]
   


    */