using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Cooks", story: "[Self] cooks Potion every [CookingTime]s", category: "Action", id: "fa4777f64c7eae3262e39c3fdb9267f5")]
public partial class CooksAction : Action
{
    [SerializeReference] public BlackboardVariable<Healer> Self;
    [SerializeReference] public BlackboardVariable<float> CookingTime;

    private float timer = 0f;

    protected override Status OnStart()
    {
        timer = 0f;
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        timer += Time.deltaTime;

        if (timer >= CookingTime)
        {
            Self.Value.CookPotion();
            timer = 0f;

            if (!Self.Value.CanCook()) return Status.Success;
        }
        
        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

