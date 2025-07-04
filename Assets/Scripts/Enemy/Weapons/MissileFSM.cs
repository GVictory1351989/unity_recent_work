using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MissileFSM : FSMAbstract<MissileFSM>
{
    public Transform Target { get; private set; }
    public float Speed { get; private set; }
    public float RotateSpeed { get; private set; }
    public float Damage { get; private set; }
    public void Init(Transform target, float speed, float rotateSpeed, float damage)
    {
        Target = target;
        Speed = speed;
        RotateSpeed = rotateSpeed;
        Damage = damage;
    }

    protected override IFSMState<MissileFSM> GetInitialState()
    {
        return new MissileFly();
    }
}

