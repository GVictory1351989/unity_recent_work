using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletFSM : FSMAbstract<BulletFSM>, IEnemy
{
    public Transform Target { get; private set; }
    public Vector3 Direction { get; private set; }
    public int Health { get; set; }
    public float FireRate { get; set; }
    public float StayTime { get; set; }
    public float AvoidRadius { get; set; }
    public float AttackCooldown { get; set; }
    public float Damage { get; set; }
    public float Speed { get; set; }
    public float RotateSpeed { get; set; }
    public Vector3 TargetPoint { get; set; }
    public Transform Player;
    public EnemyType EnemyType => EnemyType.None;
    protected override IFSMState<BulletFSM> GetInitialState()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        if (Player == null)
            return new BulletHit();
        return new BulletFly();
    }
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

