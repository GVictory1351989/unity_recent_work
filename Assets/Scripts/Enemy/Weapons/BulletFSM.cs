using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletFSM : FSMAbstract<BulletFSM>
{
    public Transform Target { get; private set; }
    public Vector3 Direction { get; private set; }
    public float Speed { get; private set; }
    public void Init(Transform target, float speed, float damage)
    {
        Target = target;
        Speed = speed;
        if (target != null)
            Direction = (target.position - transform.position).normalized;
        else
            Direction = transform.forward;
    }

    protected override IFSMState<BulletFSM> GetInitialState()
    {
        return new BulletFly();
    }
}

