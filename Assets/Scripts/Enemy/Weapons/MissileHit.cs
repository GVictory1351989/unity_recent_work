using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MissileHit : IFSMState<MissileFSM>
{
    public void Enter(FSMAbstract<MissileFSM> fsm)
    {
        var missile = fsm as MissileFSM;
        EventManager.Publish(null, new GameEvent<Component>(missile));
    }
    public void Update(FSMAbstract<MissileFSM> fsm) { }
    public void Exit(FSMAbstract<MissileFSM> fsm) { }
}

