using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "SearchPlayer", story: "[Self] is searching for [Target]", category: "Action", id: "f39f3d92a8163c046a56a73a910d8aab")]
public partial class SearchPlayerAction : Action
{
    [SerializeReference] public BlackboardVariable<SensorSystem> Self;
    [SerializeReference] public BlackboardVariable<GameObject> Target;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        GameObject possibleTarget = Self.Value.Search();

        if (Target.Value == null && possibleTarget != null)
        {
            Target.Value = possibleTarget;
            return Status.Success;
        }
        else if (possibleTarget == null)
        {
            if (Target.Value != null)
            {
                Target.Value = null;
                return Status.Failure;
            }
            
        }

        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

