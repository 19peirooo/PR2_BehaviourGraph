using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "HasBeenFound", story: "[Target] has found [Self]", category: "Conditions", id: "48fdfa32c69fb8b0486c96895513f3b1")]
public partial class HasBeenFoundCondition : Condition
{
    [SerializeReference] public BlackboardVariable<GameObject> Target;
    [SerializeReference] public BlackboardVariable<GameObject> Self;

    public override bool IsTrue()
    {
        return Target.Value != null;
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
