using System;
using UnityEngine;
public class RangedEnemy : FSMAbstract<RangedEnemy> , IEnemy
{
    public Transform Player;
    public Vector3 TargetPoint { get; set; }
    public int Health { get; set; }
    public float FireRate { get; set; }
    public float StayTime { get; set; }
    public float AvoidRadius { get; set; }
    public float AttackCooldown { get; set; }
    public float Damage { get; set; }
    public EnemyType EnemyType => EnemyType.Ranged;
    public WeaponConfigSO WeaponConfig { get; private set; }
    protected override IFSMState<RangedEnemy> GetInitialState()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        return new RangedIdle();
    }
    public void SetEntityConfigSO(WeaponConfigSO weapon)
    {
        WeaponConfig = weapon;
        AvoidRadius = weapon.Range;
        AttackCooldown = weapon.Cooldown;
        Damage = weapon.Damage;
        StayTime = weapon.StayTime;
        Health = weapon.Health;
    }
}

