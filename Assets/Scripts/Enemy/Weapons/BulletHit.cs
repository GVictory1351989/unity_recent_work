using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletHit : IFSMState<BulletFSM>
{
    public void Enter(FSMAbstract<BulletFSM> fsm)
    {
        var bullet = fsm as BulletFSM;
        EventManager.Publish(null, new GameEvent<Component>(bullet));
    }

    public void Update(FSMAbstract<BulletFSM> fsm) { }
    public void Exit(FSMAbstract<BulletFSM> fsm) { }
}

