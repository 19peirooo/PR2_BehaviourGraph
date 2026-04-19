    using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "HasHealingPotions", story: "[Self] has healing potions", category: "Action", id: "f56739a3962013d6b006a6bd944d400b")]
public partial class HasHealingPotionsAction : Action
{
    [SerializeReference] public BlackboardVariable<Healer> Self;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Self.Value.GetNumPotions() <= 0 ? Status.Failure : Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

