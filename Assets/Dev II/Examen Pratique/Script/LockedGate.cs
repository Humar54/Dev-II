
using UnityEngine;

public class LockedGate : Gate
{
    private bool _isUnlock;

    private void Start()//2pts
    {
        ControlManager._OnToggleLock += SetLockState;
        // Abonner la fonction SetLockState � l'event _OnToogleLock du ControlManager
    }

    protected override void OpenDoor()
    {
        if(_isUnlock)
        {
            base.OpenDoor();
        }
    }

    private void SetLockState(bool lockState)
    {
        _isUnlock = lockState;
    }


    //Fonction surcharg� de l'enfant OpenDoor() //2pts
    //{
    // Ouvrir la porte si la porte est d�bar�e
    //}

    //Fonction sp�cifique � l'enfant SetLockState //2 pts
    //{
    // Barrer ou d�barer la porte (applique la valeur apropri�e � la variable _isUnlock)
    //}


}
