
using UnityEngine;
using UnityEngine.Scripting;

[Preserve]
[FSMState("Idle", isInitial: true)]
public class MeleeIdle : IFSMState<MeleeEnemy>
{
    private float timer;
    public void Enter(FSMAbstract<MeleeEnemy> fsmentity)
    {
        timer = 0.5f;
    }

    public void Update(FSMAbstract<MeleeEnemy> fsmentity)
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            fsmentity.ChangeStateByName("Chase");
        }
    }
    public void Exit(FSMAbstract<MeleeEnemy> fsmentity)
    {
    }
}
