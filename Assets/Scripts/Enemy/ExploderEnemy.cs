using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ExploderEnemy : Enemy
{
    protected override void MoveTowardsTarget(Vector3 targetPoint)
    {
        Vector3 direction = (targetPoint - Position).normalized;
        Position += direction * Time.deltaTime * 4f; // Fast rush

        float explodeDistance = 1.5f;
        if (Vector3.Distance(Position, targetPoint) < explodeDistance)
        {
            Explode();
        }
    }

    private void Explode()
    {
        Debug.Log("Boom! Enemy exploded.");
        // Add damage logic + destroy or pool return
    }
}
