using System;
using UnityEngine;

public enum States
{ Idle, Patrol, Pursuite};

public class StateMachine : MonoBehaviour
{
    public event Action<BaseState> OnStateChanged = delegate { };

    private BaseState currentState;

    public BaseState CurrentState
    {
        get { return currentState; }
    }

    public void Init(BaseState intialState)
    {
        currentState = intialState;
        currentState.Enter();
    }

    public void ChangeState(BaseState state)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = state;
        currentState.Enter();

        if (OnStateChanged != null)
        {
            OnStateChanged(currentState);
        }
    }
    public BaseState GetCurrentState()
    {
        return currentState;
    }

    private void Update()
    {
        if (currentState == null) return;

        currentState.Update();
    }
}
