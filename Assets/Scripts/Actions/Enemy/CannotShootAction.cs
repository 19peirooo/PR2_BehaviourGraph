using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "CannotShoot", story: "[Self] cannot shoot [Target] in range [ShootRange]", category: "Action", id: "9f034a5e0fefd6b62fd2401a2fe1c0e0")]
public partial class CannotShootAction : Action
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

        bool inRange = dist <= ShootRange;
        bool obstacle = Self.Value.ObstacleDetected(dirToTarget);

        if (!inRange || obstacle)
        {
            return Status.Success;
        }
            

        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

