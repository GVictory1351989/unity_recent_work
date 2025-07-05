using UnityEngine;
using System;
using UnityEngine.Scripting;

[Preserve]
[FSMState("Attack")]
public class MeleeAttack : IFSMState<MeleeEnemy>
{
    private float timer = 0f;
    public void Enter(FSMAbstract<MeleeEnemy> fsmentity)
    {
        timer = 0f;
    }
    public void Update(FSMAbstract<MeleeEnemy> fsmentity)
    {
        var enemy = fsmentity as MeleeEnemy;
        timer += Time.deltaTime;
        float dist = Vector3.Distance(enemy.TargetPoint, fsmentity.transform.position);
        if (dist > enemy.AvoidRadius)
        {
            fsmentity.ChangeStateByName("Chase");
            return;
        }
        if (timer >= enemy.AttackCooldown)
        {
            timer = 0f;
            PerformAttack(enemy);
        }
    }

    public void Exit(FSMAbstract<MeleeEnemy> fsmentity)
    {
    }

    private void PerformAttack(FSMAbstract<MeleeEnemy> fsmentity)
    {
        Component bulletObj = PoolManager.GetByType(typeof(BulletFSM));
        bulletObj.transform.position = fsmentity.transform.position + Vector3.up;
    }
}

