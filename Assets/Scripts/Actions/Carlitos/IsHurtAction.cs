using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using Random = UnityEngine.Random;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "IsHurt", story: "[Self] is Hurt", category: "Action", id: "85276a4ae53fc2ec7aea5fbf0494f123")]
public partial class IsHurtAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;

    private float timer = 0f;

    private float minCryTime = 10f;
    private float maxCryTime = 20f;

    private float timeUntilCry;

    protected override Status OnStart()
    {
        timeUntilCry = Random.Range(minCryTime,maxCryTime);
        timer = 0f;
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        timer += Time.deltaTime;

        if (timer >= timeUntilCry) return Status.Success;

        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

