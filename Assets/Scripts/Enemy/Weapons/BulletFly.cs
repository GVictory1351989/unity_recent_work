using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletFly : IFSMState<BulletFSM>
{
    public void Enter(FSMAbstract<BulletFSM> fsm) { }
    public void Update(FSMAbstract<BulletFSM> fsm)
    {
        var bullet = fsm as BulletFSM;
        Vector3 direction =bullet.Player.position- bullet.transform.position;
        Vector3 unit = direction.normalized;
        bullet.transform.position += unit * bullet.Speed * Time.deltaTime;
        if (Vector3.Distance(fsm.transform.position, bullet.Player.position) < 0.5f)
        {
            fsm.ChangeState(new BulletHit());
        }
    }

    public void Exit(FSMAbstract<BulletFSM> fsm) { }
}

