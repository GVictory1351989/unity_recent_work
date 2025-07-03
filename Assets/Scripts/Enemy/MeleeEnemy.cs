using UnityEngine;
public class MeleeEnemy : Enemy
{
    protected override void MoveTowardsTarget(Vector3 targetPoint)
    {
        Vector3 direction = (targetPoint - Position).normalized;
        Position += direction * Time.deltaTime * 3f; // Faster approach
    }
}
