using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    [SerializeField] private StateMachine _stateMachine;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Transform _patrolPoint1;
    [SerializeField] private Transform _patrolPoint2;
    [SerializeField] private Transform _target;
    [SerializeField] protected States _state;
    [SerializeField] private float _minStopDist = 0.5f;

    protected States _previous_State;
    private Vector3 _starPos;

    private void Start()
    {
        _starPos = transform.position;
    }

    private void Update()
    {
        // Check if there was a change of state and if so it will call the ChangeState fonction
        if (_previous_State != _state)
        {
            _previous_State = _state;
            ChangeState(_state);
        }
    }

    protected virtual void ChangeState(States state)
    {

        //Change to the matching state and initialize the state before passing it to the statemachine
        switch (_state)
        {
            case States.Idle:
                IdleState Idle = new();
                Idle.init(_starPos, _minStopDist, _agent);
                _stateMachine.ChangeState(Idle);
                break;
            case States.Patrol:
                PatrolState patrol = new();
                patrol.init(_patrolPoint1.position, _patrolPoint2.position, _minStopDist, _agent);
                _stateMachine.ChangeState(patrol);
                break;
            case States.Pursuite:
                ChaseState pursuite = new();
                pursuite.init(_target, _agent, _minStopDist);
                _stateMachine.ChangeState(pursuite);
                break;
            default:
                break;
        }
    }
}
