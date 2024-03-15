
using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] protected int _ammunition;
    [SerializeField] protected int _magazineSize;
    [SerializeField] protected float _reloadTime;

    public virtual void Shoot()
    {
        if(_ammunition > 0)
        {
            LaunchProjectile();
            _ammunition--;
        }
        else
        {
            Debug.Log("Click! Out of ammo!");
        }
    }

    public void Reaload()
    {
        Debug.Log("Reloading....");
        StartCoroutine(ReloadAfterDelay());
    }

    private IEnumerator ReloadAfterDelay()
    {
        yield return new WaitForSeconds(_reloadTime);
        Debug.Log("Loaded");
        _ammunition = _magazineSize;
    }

    protected virtual void LaunchProjectile()
    {
        EmitGunFireSound();
        Debug.Log("Lauch projectile in a straigth line");
    }

    protected void EmitGunFireSound()
    {
        Debug.Log("Bang!");
    }


}
