
using UnityEngine;
public class ExplodeIdle : IFSMState<ExplodedEnemy>
{
    private float timer;
    private float waitTime = 0.5f;
    private Transform player;
    public void Enter(FSMAbstract<ExplodedEnemy> enemy)
    {
        player = GameObject.FindWithTag("Player").transform; // for hurry 
        timer = 0f;
    }
    public void Update(FSMAbstract<ExplodedEnemy> enemy)
    {
        timer += Time.deltaTime;
        if (Vector3.Distance(player.position, enemy.transform.position) > 1f)
        {
            enemy.ChangeState(new ExplodeChase());
        }
        else if (timer >= waitTime)
        {
            timer = 0f;
        }
    }
    public void Exit(FSMAbstract<ExplodedEnemy> enemy) { }
}
