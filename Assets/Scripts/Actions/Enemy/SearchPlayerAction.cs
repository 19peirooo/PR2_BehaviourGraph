using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "SearchPlayer", story: "[Self] is searching for [Target] storing [LastKnownLocation]", category: "Action", id: "f39f3d92a8163c046a56a73a910d8aab")]
public partial class SearchPlayerAction : Action
{
    [SerializeReference] public BlackboardVariable<SensorSystem> Self;
    [SerializeReference] public BlackboardVariable<GameObject> Target;
    [SerializeReference] public BlackboardVariable<Vector3> LastKnownLocation;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        GameObject possibleTarget = Self.Value.Search();
        
        // Si no tengo ningún objetivo e identifico algo nuevo...
        if(Target.Value == null && possibleTarget != null)
        {
            Target.Value = possibleTarget;
            return Status.Success;
        }
        // Si no identifico nada con el SensorSystem
        else if(possibleTarget == null)
        {
            if (Target.Value != null)
            {
                // comunico al arbol la última posición conocida del objetivo.
                LastKnownLocation.Value = Target.Value.transform.position;
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

