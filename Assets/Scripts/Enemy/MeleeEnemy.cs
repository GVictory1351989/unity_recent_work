using System;
using UnityEngine;
public class MeleeEnemy : FSMAbstract<MeleeEnemy>, IEnemy 
{
    public Vector3 TargetPoint { get; set; }
    public EnemyType EnemyType => EnemyType.Melee;
    public GameObject Slider;
    protected override IFSMState<MeleeEnemy> GetInitialState()
    {
        TargetPoint = GameObject.FindWithTag("Player").transform.position;
        Slider = transform.Find("Slider").gameObject;
        return new MeleeIdle();
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
        if (Health==0)
        {
            EventManager.Publish(null, new GameEvent<Component>(this));
            Health = GlobalHealth;
            Slider.transform.localScale = Vector3.one;
        }
    }
}

