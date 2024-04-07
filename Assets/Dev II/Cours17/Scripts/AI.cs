using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    [SerializeField] private StateMachine _stateMachine;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Transform _patrolPoint1;
    [SerializeField] private Transform _patrolPoint2;
    [SerializeField] private Transform _target;
    [SerializeField] protected States _previous_State;
    [SerializeField] protected States _state;
    [SerializeField] private float _minStopDist = 0.5f;

    private Vector3 _starPos;
    private int _stateIndex;

    private void Start()
    {
        _starPos = transform.position;
    }

    private void Update()
    {
        if (_previous_State != _state)
        {
            _previous_State = _state;
            ChangeState(_state);
        }
    }

    protected virtual void ChangeState(States state)
    {
        switch (_state)
        {
            case States.Idle:
                IdleState Idle = new(States.Idle.ToString());
                Idle.init(_starPos, _minStopDist, _agent);
                _stateMachine.ChangeState(Idle);
                break;
            case States.Patrol:
                PatrolState patrol = new(States.Patrol.ToString());
                patrol.init(_patrolPoint1.position, _patrolPoint2.position, _minStopDist, _agent);
                _stateMachine.ChangeState(patrol);
                break;
            case States.Pursuite:
                ChaseState pursuite = new(States.Pursuite.ToString());
                pursuite.init(_target, _agent, _minStopDist);
                _stateMachine.ChangeState(pursuite);
                break;
            default:
                break;
        }
    }
}
