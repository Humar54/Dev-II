
using UnityEngine;

public class ShotGun : Gun
{
    public override void Shoot()
    {
        if (_ammunition > 0)
        {
            Debug.Log("Recoil!");
        }
        base.Shoot();
    }
    protected override void LaunchProjectile()
    {
        EmitGunFireSound();
        Debug.Log("Launch a volley of projectile");
    }
}
