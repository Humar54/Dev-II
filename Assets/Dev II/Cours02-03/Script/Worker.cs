
using UnityEngine;

public class Worker : MonoBehaviour
{
    [SerializeField] protected RessourcesManager _manager;
    [SerializeField] protected int _foodConsumptionRate;
    [SerializeField] protected int _production;

    private void Start()
    {
        _manager = transform.parent.GetComponent<RessourcesManager>();
    }

    // Impl�menter la fonction Work qui consomme de la nourriture
    // � chaque fois qu'un Worker travaille

    public virtual void Work()
    {
        _manager.AddFood(-_foodConsumptionRate);
    }
}
