using UnityEngine;

/// <summary>
/// MeleeEnemy ke liye attack state — attack karta hai jab target range mein ho.
/// </summary>
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
