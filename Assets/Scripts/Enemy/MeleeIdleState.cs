using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
public class MeleeIdleState : IFSMState<MeleeEnemy>
{
    private float idleTime = 0f;
    private float maxIdle = 1f;

    public void Enter(FSMAbstract<MeleeEnemy> enemy)
    {
        idleTime = 0f;
    }

    public void Exit(FSMAbstract<MeleeEnemy> enemy)
    {
    }
    public void Update(FSMAbstract<MeleeEnemy> enemy)
    {
        idleTime += Time.deltaTime;
        if (idleTime >= maxIdle)
        {
            enemy.ChangeState(new MeleeMoveState());
        }
    }
}
