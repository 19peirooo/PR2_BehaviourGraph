using System;
using Unity.Behavior;
using UnityEngine;
using Modifier = Unity.Behavior.Modifier;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "RepeatXTimes", story: "Repeat [X] Times", category: "Flow", id: "c611281f8b19b24e27ef663febf64e33")]
public partial class RepeatXTimesModifier : Modifier
{
    [SerializeReference] public BlackboardVariable<int> X;

    private int counter = 0;

    protected override Status OnStart()
    {
        StartNode(Child);
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        var status = Child.CurrentStatus;
        if (status == Status.Success)
        {
            counter++;
            if (counter < X)    // minus 1 becouse we start the first call onStart()
            {
                StartNode(Child);
            }
            else
            {
                counter = 0;    // se han terminado todas las iteraciones, reseteo counter y comunico el error
                return Status.Success;
            }
        }
        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

