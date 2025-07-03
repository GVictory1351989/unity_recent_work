using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EAttackState : IEnemyState
{
    private float attackCollDown = 1f;
    private float lastAttacktime;
    public void Enter(Enemy enemy)
    {
        lastAttacktime = Time.unscaledTime;
    }
    public void Update(Enemy enemy)
    {
        float timeNow = Time.unscaledTime;
        if (Vector3.Distance(enemy.transform.position, enemy.TargetPoint) > 2f)
        {
            enemy.ChangeState(new EChaseState());
            return;
        }
        if (timeNow - lastAttacktime >= attackCollDown)
        {
            lastAttacktime = timeNow;
            PerformAttack(enemy);
        }
    }
    public void Exit(Enemy enemy)
    {
        Debug.Log("Exiting Attack State");
    }

    private void PerformAttack(Enemy enemy)
    {
        Debug.Log("Enemy attacks!");
    }
}
