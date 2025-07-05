using System;
using UnityEngine;
public class ExplodedEnemy : FSMAbstract<ExplodedEnemy>, IEnemy
{
    public Vector3 TargetPoint { get; set; }
    public EnemyType EnemyType => EnemyType.Explode;
    public WeaponConfigSO WeaponConfig { get; private set; }
    protected override IFSMState<ExplodedEnemy> GetInitialState()
    {
        return new ExplodeIdle();
    }
    public int Health { get; set; }
    public float FireRate { get; set; }
    public float StayTime { get; set; }
    public float AvoidRadius { get; set; }
    public float AttackCooldown { get; set; }
    public float Damage { get; set; }
    public float Speed { get; set; }
    public float RotateSpeed { get; set; }
    private int GlobalHealth;
    public void SetEntityConfigSO(float range,
                                 float cooldown,
                                 float damage,
                                 float staytime,
                                 int health,
                                 float speed,
                                 float rotateSpeed
                                 )
    {
        AvoidRadius = range;
        AttackCooldown = cooldown;
        Damage = damage;
        StayTime = staytime;
        Health = health;
        Health = health;
        Speed = speed;
        RotateSpeed = rotateSpeed;
    }
    public override void FSMHitted()
    {
        Health--;
        if (Health == 0)
        {
            EventManager.Publish(null, new GameEvent<Component>(this));
            Health = GlobalHealth;
        }
    }
}

