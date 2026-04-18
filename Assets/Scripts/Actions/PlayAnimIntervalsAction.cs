using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "PlayAnimIntervals", story: "[Self] plays anim in [param] every [secs] s", category: "Action", id: "ea5fa7d2c24787bbf38b13708873e596")]
public partial class PlayAnimIntervalsAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<string> Param;
    [SerializeReference] public BlackboardVariable<float> Secs;

    private Animator anim;
    private float timer;

    protected override Status OnStart()
    {
        anim = Self.Value.GetComponent<Animator>();
        timer = 0f;
        return Status.Running;
    }

    protected override Status OnUpdate()
    {

        timer += Time.deltaTime;

        if (timer >= Secs.Value)
        {
            timer = 0f;
            anim.SetTrigger(Param.Value);
        }
        
        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

