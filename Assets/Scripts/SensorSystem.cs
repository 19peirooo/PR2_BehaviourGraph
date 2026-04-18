using System;
using UnityEngine;

public class SensorSystem : MonoBehaviour
{
    
    [field: SerializeField] public float sensorRadius { get; private set; }
    [field: SerializeField] public float sensorAngle { get; private set; }

    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private LayerMask obstacleLayer;

    private void FixedUpdate()
    {
        Search();
    }

    public GameObject Search()
    {
        
        Collider[] results = Physics.OverlapSphere(transform.position, sensorRadius, targetLayer);
        //Esfera de Detección
        if (results.Length <= 0) return null;
        
        Collider target = results[0];
        Vector3 directionToTarget = target.transform.position - transform.position;
        
        //Cono de detección
        if (Vector3.Angle(transform.forward, directionToTarget) > sensorAngle / 2) return null;
        
        //Comprobación Obstaculos
        if (ObstacleDetected(directionToTarget)) return null;
        
        return target.gameObject;

    }
    
    public Vector3 DirFromAngle(float angle, bool relativeToSelf)
    {
        if (relativeToSelf)
        {
            angle += transform.eulerAngles.y;
        }
        Vector3 direction = new Vector3(Mathf.Sin(angle* Mathf.Deg2Rad) , 0, Mathf.Cos(angle * Mathf.Deg2Rad));
        return direction;
    }

    public bool ObstacleDetected(Vector3 direction)
    {
        return Physics.Raycast(transform.position, direction, direction.magnitude, obstacleLayer);
    }
}
