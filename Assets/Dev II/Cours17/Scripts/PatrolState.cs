
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : BaseState
{
    private NavMeshAgent _agent;
    private Vector3 _patrolPoint1;
    private Vector3 _patrolPoint2;
    private float _minDist;

    public void init(Vector3 Pos1, Vector3 Pos2 ,float minDist,NavMeshAgent agent)
    {
        _patrolPoint1 = Pos1;
        _patrolPoint2 = Pos2;
        _minDist = minDist;
        _agent = agent;
    }

    public PatrolState(string id) : base(id)
    {
    }

    public override void Enter()
    {
        _agent.SetDestination(_patrolPoint1);
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
        if((_agent.transform.position -_patrolPoint1).magnitude < _minDist)
        {
            _agent.SetDestination(_patrolPoint2);
        }

        if ((_agent.transform.position - _patrolPoint2).magnitude < _minDist)
        {
            _agent.SetDestination(_patrolPoint1);
        }
    }
}
