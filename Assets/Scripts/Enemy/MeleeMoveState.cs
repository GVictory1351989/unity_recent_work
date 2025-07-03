using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class MeleeMoveState : IFSMState<MeleeEnemy>
{
    private float moveSpeed = 3f;
    private float attackRange = 1.5f;

    public void Enter(FSMAbstract<MeleeEnemy> fsmentity)
    {
    }

    public void Exit(FSMAbstract<MeleeEnemy> fsmentity)
    {
    }

    public void Update(FSMAbstract<MeleeEnemy> fsmentity)
    {
        MeleeEnemy enemy = (MeleeEnemy)fsmentity;

        Vector3 direction = (enemy.TargetPoint - enemy.transform.position).normalized;
        enemy.transform.position += direction * moveSpeed * Time.deltaTime;

        float distance = Vector3.Distance(enemy.transform.position, enemy.TargetPoint);
        if (distance <= attackRange)
        {
            enemy.ChangeState(new MeleeAttackState());
        }
    }
}
