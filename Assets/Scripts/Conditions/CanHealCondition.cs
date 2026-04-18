using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "CanHeal", story: "[Self] can heal [Ally]", category: "Conditions", id: "3f21d49046b01bd364474540d85a8c94")]
public partial class CanHealCondition : Condition
{
    [SerializeReference] public BlackboardVariable<Healer> Self;
    [SerializeReference] public BlackboardVariable<GameObject> Ally;

    public override bool IsTrue()
    {
        return Self.Value.GetNumPotions() >= 0;
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
