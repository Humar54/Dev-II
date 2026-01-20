

using UnityEngine;

public class Sniper : Gun
{
    //Variable unique au sniper (il peut viser comparativement aux autres guns)
    private bool _isAiming;
    void Update()
    {
        // Le sniper ajoute un comportement propre (viser),
        // mais ne modifie pas Shoot() ou LaunchProjectile().
        // → Il hérite donc du comportement standard de Gun.
        // mais en ajoute un unique à lui même.

        if (Input.GetMouseButton(1))
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
