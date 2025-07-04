using System;
using UnityEngine;
public class MeleeEnemy : FSMAbstract<MeleeEnemy>, IEnemy
{
    public Vector3 TargetPoint { get; set; }
    public int Health { get; set; }
    public float FireRate { get; set; }
    public float StayTime { get; set; }
    public float AvoidRadius { get; set; }
    public float AttackCooldown { get; set; }
    public float Damage { get; set; }

    public EnemyType EnemyType => EnemyType.Melee;
    public WeaponConfigSO WeaponConfig { get; private set; }
    protected override IFSMState<MeleeEnemy> GetInitialState()
    {
        return new MeleeIdle();
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

