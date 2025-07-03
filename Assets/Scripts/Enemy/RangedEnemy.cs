using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RangedEnemy : Enemy
{
    public override void MoveTowardsTarget(Vector3 targetPoint)
    {
        float stopDistance = 5f;
        Vector3 direction = targetPoint - transform.position;
        if (direction.magnitude > stopDistance)
        {
            transform.position += direction.normalized * Time.deltaTime * 2f;
        }
    }
}
