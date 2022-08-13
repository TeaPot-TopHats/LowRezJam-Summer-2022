using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySensors : MonoBehaviour
{
    
    [SerializeField] private LayerMask PlayerLayer;
    [SerializeField] private Transform Sensor;
    [SerializeField] private Transform AttackArea;
    [SerializeField] private float sensorRadius;
    [SerializeField] private float attackRadius;
    [SerializeField] public Vector3 TargetPosition { get; private set; }
    [SerializeField] public bool seePlayer { get; private set; }
    [SerializeField] public bool canAttack { get; private set; }

    // Update is called once per frame
    void Update()
    {
        seePlayer = Physics2D.OverlapCircle(Sensor.position, sensorRadius, PlayerLayer);
        if(seePlayer)
            TargetPosition = Physics2D.OverlapCircle(Sensor.position, sensorRadius, PlayerLayer).ClosestPoint(transform.position);
        canAttack = Physics2D.OverlapCircle(AttackArea.position, attackRadius, PlayerLayer);
    }

    public Collider2D recordTarget()
    {
        if(canAttack)
            return Physics2D.OverlapCircle(AttackArea.position, attackRadius, PlayerLayer);
        return null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(Sensor.position, sensorRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackArea.position, attackRadius);

    }
}
