using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] protected Animator _doorAnimator;
    private void Awake()
    {
        ControlManager._OnGateOpen += OpenDoor;
        ControlManager._OnGateClose += CloseDoor;
    }

    protected virtual void CloseDoor()
    {
        _doorAnimator.SetBool("Open", false);
        _doorAnimator.SetBool("Close", true);
    }

    protected virtual void OpenDoor()
    {
        _doorAnimator.SetBool("Close",false);
        _doorAnimator.SetBool("Open", true);
    }

    /*
    private void Awake()
    {
        //Abonner les fonctions OpenDoor et CloseDoor au _OnGateOpen et au _OngateCloseEvent du ControlManager
    }

    protected virtual void CloseDoor()
    {
        //Assigner les booléens de l'animator de la portes (Le "Open" et le "Close) pour fermer la porte"
    }

    protected virtual void OpenDoor()
    {
         //Assigner les booléens de l'animator de la portes (Le "Open" et le "Close) pour ouvrir la porte"
    }
    */
}
