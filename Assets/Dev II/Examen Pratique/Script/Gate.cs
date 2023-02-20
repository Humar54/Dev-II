using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] protected Animator _doorAnimator;
    private void Awake()//2pts
    {
        ControlManager._OnGateOpen += OpenDoor;
        ControlManager._OnGateClose += CloseDoor;
        //Abonner les fonctions OpenDoor et CloseDoor au _OnGateOpen et au _OngateCloseEvent du ControlManager
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
    //Fonction CloseDoor() //1 pts
    //{
        //Assigner les booléens de l'animator de la portes (Le "Open" et le "Close) pour fermer la porte"
    //}

    //Fonction OpenDoor() //1 pts
    //{
        //Assigner les booléens de l'animator de la portes (Le "Open" et le "Close) pour ouvrir la porte"
    //}
    */
}
