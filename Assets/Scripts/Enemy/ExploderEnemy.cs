using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ExploderEnemy : Enemy
{
    /// <summary>
    /// Move towards target different type of enemies one exploder enemy 
    /// </summary>
    /// <param name="targetPoint"></param>
    public override void MoveTowardsTarget(Vector3 targetPoint)
    {
        Vector3 direction = (targetPoint - transform.position).normalized;
        transform.position += direction * Time.deltaTime * 4f; // Fast rush
        float explodeDistance = 1.5f;
        if (Vector3.Distance(transform.position, targetPoint) < explodeDistance)
        {
            Explode();
        }
    }

    private void Explode()
    {
        Debug.Log("Boom! Enemy exploded.");
    }
}
