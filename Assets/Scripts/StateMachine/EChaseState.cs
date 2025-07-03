using UnityEngine;
public class EChaseState : IEnemyState
{
    private float attackRange = 1.5f;
    public void Enter(Enemy enemy)
    {
        Debug.Log($"{enemy.name} entered Chase State");
    }
    public void Exit(Enemy enemy)
    {
        Debug.Log($"{enemy.name} exited Chase State");
    }
    public void Update(Enemy enemy)
    {
        enemy.MoveTowardsTarget(enemy.TargetPoint);
        float distance = Vector3.Distance(enemy.transform.position, enemy.TargetPoint);
        if (distance <= attackRange)
        {
            enemy.ChangeState(new EAttackState());
        }
    }
}
