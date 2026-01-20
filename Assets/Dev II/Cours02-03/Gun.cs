

using System.Collections;
using UnityEngine;


// Gun est la classe parent 
public class Gun : MonoBehaviour
{
    // Les champs sont "protected" :
    // → accessibles dans les classes enfants (ShotGun, Sniper), → mais pas accessibles depuis l'extérieur.

    [SerializeField] protected int _ammunition;
    [SerializeField] protected int _magazineSize;
    [SerializeField] protected float _reloadTime;

    // Public pour que l'humain puisse l'appeler.
    // Méthode virtuelle : les classes enfants peuvent la remplacer/redéfinir (override).
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

    // Public pour que l'humaine puisse l'appeler
    // pas virtuelle: Ce qui veut dire qu'on considère que tout les gun se rechargent de la même manière
    // et appellent la fonction de la classe parent directement
    public void Reaload()
    {
        Debug.Log("Reloading....");
        StartCoroutine(ReloadAfterDelay());
    }

    // appeler par reload et rien d'autre aucun enfant ni classe extérieure donc private seulement 
    private IEnumerator ReloadAfterDelay()
    {
        yield return new WaitForSeconds(_reloadTime);
        Debug.Log("Loaded");
        _ammunition = _magazineSize;
    }

    // Méthode virtuelle : les enfants peuvent changer la façon de tirer.
    // (pour pouvoir override une fonction elle doit obligatoirement être protected ou public)
    // si non pas accessible...
    protected virtual void LaunchProjectile()
    {
        EmitGunFireSound();
        Debug.Log("Lauch projectile in a straigth line");
    }

    // Méthode protégée : accessible aux classes enfants,
    // mais pas modifiable puisque  (pas virtual).
    protected void EmitGunFireSound()
    {
        Debug.Log("Bang!");
    }
}
