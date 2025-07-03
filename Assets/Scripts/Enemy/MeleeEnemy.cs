using UnityEngine;
public class MeleeEnemy : Enemy
{
    public override void MoveTowardsTarget(Vector3 targetPoint)
    {
        Vector3 direction = (targetPoint - transform.position).normalized;
        transform.position += direction * Time.deltaTime * 3f; 
    }
}
