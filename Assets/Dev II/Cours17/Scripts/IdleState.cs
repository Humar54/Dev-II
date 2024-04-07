using UnityEngine;
using UnityEngine.AI;

public class IdleState : BaseState
{
    private NavMeshAgent _agent;
    private Vector3 _startPos;
    private float _minDist;

    public void init(Vector3 origine, float minDist, NavMeshAgent agent)
    {
        _startPos = origine;
        _minDist = minDist;
        _agent = agent;
    }

    public IdleState() : base()
    {
    }

    public override void Enter()
    {
        if ((_agent.transform.position - _startPos).magnitude > _minDist)
        {
            _agent.SetDestination(_startPos);
        }
    }

    public override void Exit()
    {
    }

    public override void Update()
    {

    }
}
