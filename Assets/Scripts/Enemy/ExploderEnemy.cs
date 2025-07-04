using System;
using UnityEngine;
public class ExplodedEnemy : FSMAbstract<ExplodedEnemy>, IEnemy
{
    public Vector3 TargetPoint { get; set; }
    public int Health { get; set; }
    public float FireRate { get; set; }
    public float StayTime { get; set; }
    public EnemyType EnemyType => EnemyType.Ranged;
    public WeaponConfigSO WeaponConfig { get; private set; }
    protected override IFSMState<ExplodedEnemy> GetInitialState()
    {
        return new ExplodeIdle();
    }
    public void SetEntityConfigSO(WeaponConfigSO weapon)
    {
        WeaponConfig = weapon;
    }
}

