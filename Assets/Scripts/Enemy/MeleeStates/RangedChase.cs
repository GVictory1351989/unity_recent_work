using UnityEngine;

public class RangedChase : IFSMState<RangedEnemy>
{
    private float speed = 12f;
    private Transform player;
    public void Enter(FSMAbstract<RangedEnemy> enemy)
    {
        player = GameObject.FindWithTag("Player")?.transform;
    }
    public void Update(FSMAbstract<RangedEnemy> enemy)
    {
        if (player == null) return;
        float distance = Vector3.Distance(player.position, enemy.transform.position);
        if (distance <= 10)
        {
            enemy.ChangeState(new RangedAttack());
            return;
        }
        Vector3 direction = (player.position - enemy.transform.position).normalized;
        enemy.transform.position += direction * speed * Time.deltaTime;
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
    }

    public void Exit(FSMAbstract<RangedEnemy> enemy) { }
}
