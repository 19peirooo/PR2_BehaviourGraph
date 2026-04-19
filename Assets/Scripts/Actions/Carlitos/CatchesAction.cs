using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Catches", story: "[Self] is catched", category: "Action", id: "1bf4e8faa4bcd48c70df908485a67aae")]
public partial class CatchesAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<GameObject> Target;
    
    private float catchDistance = 1.25f;
    
    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Vector3.Distance(Self.Value.transform.position,Target.Value.transform.position) <= catchDistance
            ? Status.Success 
            : Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

