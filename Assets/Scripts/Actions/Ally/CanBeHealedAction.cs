using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "CanBeHealed", story: "[Ally] can be healed", category: "Action", id: "6a3df8391c6a043e6c39429e4fe69218")]
public partial class CanBeHealedAction : Action
{
    [SerializeReference] public BlackboardVariable<Player> Ally;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Ally.Value.GetHp() >= 100 ? Status.Failure : Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

