
using UnityEngine;
public class MeleeIdle : IFSMState<MeleeEnemy>
{
    private float timer;
    public void Enter(FSMAbstract<MeleeEnemy> fsmentity)
    {
        timer = 2f;
    }

    public void Update(FSMAbstract<MeleeEnemy> fsmentity)
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            fsmentity.ChangeState(new MeleeChase()); // Move to chase
        }
    }
    public void Exit(FSMAbstract<MeleeEnemy> fsmentity)
    {
    }
}
