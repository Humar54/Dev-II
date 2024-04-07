using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : BaseState
{
    private Transform _target;
    private NavMeshAgent _agent;
    private float _stopDist;

    public void init(Transform target, NavMeshAgent agent , float mindist)
    {
        _target = target;
        _agent = agent;
        _stopDist = mindist;
    }

    public ChaseState(string id) : base(id)
    {
    }

    public override void Enter()
    {

    }

    public override void Exit()
    {
    }

    public override void Update()
    {
        if((_target.position-_agent.transform.position).magnitude>_stopDist)
        {
            _agent.SetDestination(_target.position);
        }
        else
        {
            _agent.ResetPath();
        }
    }
}
