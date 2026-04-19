using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "WaitXSecs", story: "[Self] waits for [X] seconds", category: "Action", id: "f21e88ff3b7bf2c9088c8869dec9881c")]
public partial class WaitXSecsAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<float> X;

    private float timer;

    protected override Status OnStart()
    {
        timer = 0f;
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        timer += Time.deltaTime;

        if (timer >= X) return Status.Success;

        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

