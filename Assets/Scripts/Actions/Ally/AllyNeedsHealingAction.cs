using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "AllyNeedsHealing", story: "[Ally] Needs Healing at health [CriticalHealth] from [Self]", category: "Action", id: "78ffb67bed6433a35039dc16623a32aa")]
public partial class AllyNeedsHealingAction : Action
{
    [SerializeReference] public BlackboardVariable<Player> Ally;
    [SerializeReference] public BlackboardVariable<float> CriticalHealth;
    [SerializeReference] public BlackboardVariable<Healer> Self;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Ally.Value.GetHp() <= CriticalHealth.Value && Self.Value.CanHeal() ? Status.Success : Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

