
using UnityEngine;

public class Sniper : Gun
{
    private bool _isAiming;
    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            if(!_isAiming)
            {
                Debug.Log("ZoomIn");
            }
        }
        else
        {
            _isAiming = false;
        }
    }
}
