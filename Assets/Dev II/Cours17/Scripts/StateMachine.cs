using UnityEngine;

public enum States
{ Idle, Patrol, Pursuite };

public class StateMachine : MonoBehaviour
{
    //The stat machine contains the current state
    private BaseState currentState;

    public void ChangeState(BaseState state)
    {
        // Call the exit function on the current state
        if (currentState != null)
        {
            currentState.Exit();
        }
        // Change the actual state of the StateMachine
        currentState = state;
        // Call the Enter function on the new State
        currentState.Enter();
    }

    public BaseState GetCurrentState()
    {
        return currentState;
    }

    private void Update()
    {
        if (currentState == null) return;
        // Call the update function of the current state 
        currentState.Update();
    }
}
