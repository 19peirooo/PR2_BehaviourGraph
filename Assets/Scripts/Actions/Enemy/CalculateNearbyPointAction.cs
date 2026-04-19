using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using UnityEngine.AI;
using Random = UnityEngine.Random;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "CalculateNearbyPoint", story: "[Self] calculates [NearbyPoint] around [Point]", category: "Action", id: "bd25de491840c15b14e6cda651f4bf08")]
public partial class CalculateNearbyPointAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<Vector3> NearbyPoint;
    [SerializeReference] public BlackboardVariable<Vector3> Point;
    [SerializeReference] public BlackboardVariable<float> SearchingRadius;

    protected override Status OnStart()
    {
        Vector3 randomPoint;
        int attempts = 0;
        do
        {
            randomPoint = Point.Value + Random.insideUnitSphere * SearchingRadius;
            attempts++;
        } 
        while (!NavMesh.SamplePosition(randomPoint, out NavMeshHit hit, 1f, NavMesh.AllAreas) && attempts < 20);

        // Comunico al arbol el punto encontrado
        NearbyPoint.Value = randomPoint;
        return Status.Success;
    }
    
    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}



