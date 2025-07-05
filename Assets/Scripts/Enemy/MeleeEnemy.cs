using System;
using UnityEngine;
public class MeleeEnemy : EnemyBase<MeleeEnemy>
{
    public override EnemyType EnemyType => EnemyType.Melee;
    protected override IFSMState<MeleeEnemy> GetInitialState()
    {
        TargetPoint = GameObject.FindWithTag("Player").transform.position;
        InitSlider();
        return new MeleeIdle();
    }
}

