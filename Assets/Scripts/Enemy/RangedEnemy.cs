using System;
using UnityEngine;
public class RangedEnemy : FSMAbstract<RangedEnemy> , IEnemy
{
    public Transform Player;
    public Vector3 TargetPoint { get; set; }
    public EnemyType EnemyType => EnemyType.Ranged;
    private GameObject Slider;
    protected override IFSMState<RangedEnemy> GetInitialState()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        Slider = transform.Find("Slider").gameObject;
        return new RangedIdle();
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
        GlobalHealth = health;
    }
    public override void FSMHitted()
    {
        Health--;
        if (Slider != null)
        {
            float xScale = Utils.PercentageScale(Health, GlobalHealth);
            Vector3 scale = Slider.transform.localScale;
            scale.x = xScale;
            Slider.transform.localScale = scale;
        }
        if (Health == 0)
        {
            EventManager.Publish(null, new GameEvent<Component>(this));
            Health = GlobalHealth;
            Slider.transform.localScale = Vector3.one;
        }
    }
}

