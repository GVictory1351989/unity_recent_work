using System;
using UnityEngine;
public class RangedEnemy : EnemyBase<RangedEnemy>
{
    public Transform Player;
    public override EnemyType EnemyType => EnemyType.Ranged;
    protected override IFSMState<RangedEnemy> GetInitialState()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        InitSlider();
        return new RangedIdle();
    }
}

