using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "CanShoot", story: "[Self] can shoot [Target]", category: "Action", id: "d3bdaf1649073c066641a5e8ef0ad805")]
public partial class CanShootAction : Action
{
    [SerializeReference] public BlackboardVariable<SensorSystem> Self;
    [SerializeReference] public BlackboardVariable<GameObject> Target;
    [SerializeReference] public BlackboardVariable<float> ShootRange;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        float dist = Vector3.Distance(Target.Value.transform.position, Self.Value.transform.position);
        Vector3 dirToTarget = Target.Value.transform.position - Self.Value.transform.position;

        if (dist < ShootRange && !Self.Value.ObstacleDetected(dirToTarget))
        { 
            return Status.Success;
        }

        return Status.Running;

    }

    protected override void OnEnd()
    {
    }
}

