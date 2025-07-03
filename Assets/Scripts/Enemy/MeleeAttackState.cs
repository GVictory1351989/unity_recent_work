using UnityEngine;

/// <summary>
/// MeleeEnemy ke liye attack state — attack karta hai jab target range mein ho.
/// </summary>
public class MeleeAttackState : IFSMState<MeleeEnemy>
{
    private float attackCooldown = 1.5f;
    private float lastAttackTime;
    public void Enter(FSMAbstract<MeleeEnemy> fsmentity)
    {
        lastAttackTime = Time.time;
    }

    public void Exit(FSMAbstract<MeleeEnemy> fsmentity)
    {
    }

    public void Update(FSMAbstract<MeleeEnemy> fsmentity)
    {
        MeleeEnemy enemy = (MeleeEnemy)fsmentity;

        Vector3 toTarget = enemy.TargetPoint - enemy.transform.position;
        if (toTarget != Vector3.zero)
        {
            Quaternion lookRot = Quaternion.LookRotation(toTarget.normalized);
            enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, lookRot, Time.deltaTime * 5f);
        }

        if (Time.time - lastAttackTime >= attackCooldown)
        {
            lastAttackTime = Time.time;
            if (Vector3.Distance(enemy.transform.position, enemy.TargetPoint) > 1.5f)
            {
                enemy.ChangeState(new MeleeMoveState()); // Back to chase
            }
        }
    }
}
