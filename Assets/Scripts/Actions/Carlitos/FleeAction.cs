using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using UnityEngine.AI;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Flee", story: "[Self] flees from [Target]", category: "Action", id: "03e46803807e74ad8d25b66251cd1747")]
public partial class FleeAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<GameObject> Target;

    private NavMeshAgent agent;
    private Animator anim;
    
    private float fleeDistance = 10f;
    private float originalStoppingDistance;

    protected override Status OnStart()
    {
        agent = Self.Value.GetComponent<NavMeshAgent>();
        originalStoppingDistance = agent.stoppingDistance;
        agent.stoppingDistance = 0f;
        anim = Self.Value.GetComponent<Animator>();
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (Target.Value == null) return Status.Failure;
        
        anim.SetFloat("SpeedMagnitude",5.0f);
        
        Vector3 fleeDirection = (Self.Value.transform.position - Target.Value.transform.position).normalized;
        Vector3 fleePosition = Self.Value.transform.position + fleeDirection * fleeDistance;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(fleePosition, out hit, 5f, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }

        return Status.Running;

    }

    protected override void OnEnd()
    {
        anim.SetFloat("SpeedMagnitude",0f);
        agent.stoppingDistance = originalStoppingDistance;
    }
}

