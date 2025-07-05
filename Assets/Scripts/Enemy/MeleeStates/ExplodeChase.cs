using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Scripting;

[Preserve]
[FSMState("Chase")]
public class ExplodeChase : IFSMState<ExplodedEnemy>
{
    private float speed = 18f;
    private Transform player;
    public void Enter(FSMAbstract<ExplodedEnemy> enemy)
    {
        player = GameObject.FindWithTag("Player")?.transform;
    }
    public void Update(FSMAbstract<ExplodedEnemy> enemy)
    {
        if (player == null) return;
        float distance = Vector3.Distance(player.position, enemy.transform.position);
        if (distance <=1.1)
        {
            enemy.ChangeStateByName("Attack");
            return;
        }
        Vector3 direction = (player.position - enemy.transform.position).normalized;
        enemy.transform.position += direction * speed * Time.deltaTime;
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
    }

    public void Exit(FSMAbstract<ExplodedEnemy> enemy) { }
}
