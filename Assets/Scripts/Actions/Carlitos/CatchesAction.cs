using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Catches", story: "[Target] catches [Self]", category: "Action", id: "195e0c101c81a7bb6207e64ff60e1477")]
public partial class CatchesAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Target;
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    
    private float catchDistance = 0.05f;
    
    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Vector3.Distance(Self.Value.transform.position,Target.Value.transform.position) <= catchDistance ? Status.Success : Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

