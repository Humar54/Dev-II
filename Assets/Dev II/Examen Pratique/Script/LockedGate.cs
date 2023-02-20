
using UnityEngine;

public class LockedGate : Gate
{
    private bool _isUnlock;

    private void Start()//2pts
    {
        ControlManager._OnToggleLock += SetLockState;
        // Abonner la fonction SetLockState à l'event _OnToogleLock du ControlManager
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


    //Fonction surchargé de l'enfant OpenDoor() //2pts
    //{
    // Ouvrir la porte si la porte est débarée
    //}

    //Fonction spécifique à l'enfant SetLockState //2 pts
    //{
    // Barrer ou débarer la porte (applique la valeur apropriée à la variable _isUnlock)
    //}


}
