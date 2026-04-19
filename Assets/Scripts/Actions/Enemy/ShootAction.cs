using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Shoot", story: "[Self] shoots [Target]", category: "Action", id: "c2c22ef7157622b50cda94e57259828b")]
public partial class ShootAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<GameObject> Target;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        Self.Value.transform.LookAt(Target.Value.transform);
        return Status.Running;
    }

    protected override void OnEnd()
    {
            
    }
}

