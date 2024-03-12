
using UnityEngine;

public class Animal : MonoBehaviour
{

    [SerializeField] protected string _name;

    public void Eat()
    {

    }

    public void MoveAround()
    {

    }
}

public interface IShowName
{
    string GetName();
}

public interface IWorker
{
    void Work();
}
