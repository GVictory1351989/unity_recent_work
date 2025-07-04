using UnityEngine;
using System;
public class MeleeAttack : IFSMState<MeleeEnemy>
{
    private float attackCooldown = 1.5f;
    private float timer = 0f;
    private Transform player;
    public void Enter(FSMAbstract<MeleeEnemy> fsmentity)
    {
        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        timer = 0f;
    }
    public void Update(FSMAbstract<MeleeEnemy> fsmentity)
    {
        var enemy = fsmentity as MeleeEnemy;
        timer += Time.deltaTime;
        float dist = Vector3.Distance(player.position, fsmentity.transform.position);
        if (dist > enemy.AvoidRadius)
        {
            fsmentity.ChangeState(new MeleeChase());
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
    
    }
}

