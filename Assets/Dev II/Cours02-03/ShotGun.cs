
using UnityEngine;

public class ShotGun : Gun
{
    // override : remplace le comportement de Shoot() défini dans Gun.
    // public donc peux-être appelé par l'humain
    public override void Shoot()
    {
        // On utilise les variables héritées (_ammunition)
        // Une classe enfant seulement peut y accéder vue que la variable est protected

        if (_ammunition > 0)
        {
            Debug.Log("Recoil!");
        }

        // On réutilise le comportement de base : → évite de réécrire toute la logique de Shoot().
        base.Shoot();
    }

    // Le shotgun tire plusieurs projectiles en un coup au lieu d'un seul: → on remplace la version par défaut.
    protected override void LaunchProjectile()
    {
        //émet du son comme un fusil normal
        EmitGunFireSound();
        Debug.Log("Launch a volley of projectile");
    }
}
