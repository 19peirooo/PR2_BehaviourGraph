using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "AllPotionCooked", story: "[Self] has cooked all potions", category: "Conditions", id: "a06fc74fea1e5b01ec2a1e68e6f29981")]
public partial class AllPotionCookedCondition : Condition
{
    [SerializeReference] public BlackboardVariable<Healer> Self;

    public override bool IsTrue()
    {
        return Self.Value.GetNumPotions() >= Self.Value.MaxPotions;
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
