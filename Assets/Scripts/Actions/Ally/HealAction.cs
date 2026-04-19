using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Heal", story: "[Self] heals [Ally] every [healTime]s", category: "Action", id: "1b842558819fd27649fe475d958089d8")]
public partial class HealAction : Action
{
    [SerializeReference] public BlackboardVariable<Healer> Self;
    [SerializeReference] public BlackboardVariable<Player> Ally;
    [SerializeReference] public BlackboardVariable<float> HealTime;

    private float timer = 0f;


    protected override Status OnStart()
    {
        timer = 0f;
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        timer += Time.deltaTime;
        Self.Value.transform.LookAt(Ally.Value.transform);

        if (timer >= HealTime.Value)
        {
            Self.Value.UsePotion();
            
            
            Ally.Value.Heal(Self.Value.GetHealAmount());

            timer = 0f;

            if (Self.Value.GetNumPotions() <= 0 || Ally.Value.GetHp() >= Ally.Value.GetMaxHp())
            {
                return Status.Success;
            }
        }
        
        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

