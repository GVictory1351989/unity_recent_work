using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletFly : IFSMState<BulletFSM>
{
    public void Enter(FSMAbstract<BulletFSM> fsm) { }
    public void Update(FSMAbstract<BulletFSM> fsm)
    {
        var bullet = fsm as BulletFSM;
        fsm.transform.position += bullet.Direction * bullet.Speed * Time.deltaTime;
        if (Vector3.Distance(fsm.transform.position, bullet.Target.position) < 0.5f)
        {
            fsm.ChangeState(new BulletHit());
        }
    }

    public void Exit(FSMAbstract<BulletFSM> fsm) { }
}

