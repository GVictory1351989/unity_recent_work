using UnityEngine;
using UnityEngine.Scripting;

[Preserve]
[FSMState("Attack")]
public class ExplodeAttack : IFSMState<ExplodedEnemy>
{
    public void Enter(FSMAbstract<ExplodedEnemy> fsmentity)
    {
        var exploder = fsmentity as ExplodedEnemy;
        EventManager.Publish(null, new GameEvent<Component>(exploder));
    }
    public void Exit(FSMAbstract<ExplodedEnemy> fsmentity)
    {
    }
    public void Update(FSMAbstract<ExplodedEnemy> fsmentity)
    {
       
    }
}
