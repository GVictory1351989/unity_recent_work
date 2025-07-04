using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class MissileFly : IFSMState<MissileFSM>
{
    public void Enter(FSMAbstract<MissileFSM> fsm) { }

    public void Update(FSMAbstract<MissileFSM> fsm)
    {
        var missile = fsm as MissileFSM;
        if (missile.Target == null) return;
        Vector3 dir = (missile.Target.position - fsm.transform.position).normalized;
        Quaternion lookRot = Quaternion.LookRotation(dir);
        fsm.transform.rotation = Quaternion.Slerp(fsm.transform.rotation, lookRot, missile.RotateSpeed * Time.deltaTime);
        fsm.transform.position += fsm.transform.forward * missile.Speed * Time.deltaTime;
        float distance = Vector3.Distance(missile.Target.position, fsm.transform.position);
        if (distance < 1f)
        {
            fsm.ChangeState(new MissileHit());
        }
    }

    public void Exit(FSMAbstract<MissileFSM> fsm) { }
}
