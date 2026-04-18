using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using UnityEngine.AI;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "PlayAnimAndWait", story: "[Self] plays animation in param [paramName]", category: "Action", id: "e04d30d41d92c573a4b7958d7a6d0372")]
public partial class PlayAnimAndWaitAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<string> ParamName;
    
    private float timer;
    private Animator anim;
    private NavMeshAgent agent;

    protected override Status OnStart()
    {
        timer = 0.0f;
        anim = Self.Value.GetComponent<Animator>();
        agent = Self.Value.GetComponent<NavMeshAgent>();

        agent.isStopped = true;
        anim.SetTrigger(ParamName.Value);
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        timer += Time.deltaTime;
        AnimatorStateInfo currentAnimatorStateInfo = anim.GetCurrentAnimatorStateInfo(0);
        
        // si el timer supera el tiempo de la animacion
        if (timer >= currentAnimatorStateInfo.length)
        {
            agent.isStopped = false;
            return Status.Success;
        }
        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

