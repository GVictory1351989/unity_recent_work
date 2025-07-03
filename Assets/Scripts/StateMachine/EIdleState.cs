using UnityEngine;
public class EIdleState : IEnemyState
{
    private float idleDuration = 2f; 
    private float idleTimer;
    public void Enter(Enemy enemy)
    {
        idleTimer = 0f;
    }
    public void Update(Enemy enemy)
    {
        idleTimer += Time.deltaTime;
        enemy.transform.Rotate(Vector3.up * Time.deltaTime * 20f); 
        if (idleTimer >= idleDuration)
        {
            enemy.ChangeState(new EChaseState());
        }
    }
    public void Exit(Enemy enemy)
    {

    }
}
