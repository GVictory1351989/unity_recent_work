using UnityEngine;
using UnityEngine.Scripting;

[Preserve]
[FSMState("Idle", true)]
public class RangedIdle : IFSMState<RangedEnemy>
{
    private float timer;
    private float waitTime = 0.5f;
    private Transform player;
    public void Enter(FSMAbstract<RangedEnemy> enemy)
    {
        player = GameObject.FindWithTag("Player").transform; // for hurry 
        timer = 0f;
    }
    public void Update(FSMAbstract<RangedEnemy> enemy)
    {
        timer += Time.deltaTime;
        if (Vector3.Distance(player.position, enemy.transform.position) > 10f)
        {
            enemy.ChangeStateByName("Chase");
        }
        else if (timer >= waitTime)
        {
            timer = 0f;
        }
    }
    public void Exit(FSMAbstract<RangedEnemy> enemy) { }
}
