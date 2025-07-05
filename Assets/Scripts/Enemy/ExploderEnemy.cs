using System;
using UnityEngine;
public class ExplodedEnemy : EnemyBase<ExplodedEnemy>
{
    public override EnemyType EnemyType => EnemyType.Explode;
    protected override IFSMState<ExplodedEnemy> GetInitialState()
    {
        InitSlider();
        return new ExplodeIdle();
    }
}

