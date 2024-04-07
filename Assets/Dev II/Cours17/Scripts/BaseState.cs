using UnityEngine;

public abstract class BaseState
{
    private string id;

    public string ID
    {
        get { return id; }
    }

    public BaseState(string id)
    {
        this.id = id;
    }

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}
