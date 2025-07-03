using UnityEngine;
/// <summary>
/// Base abstract class for all enemies.
/// </summary>
public abstract class Enemy : MonoBehaviour
{
    /// <summary>
    /// Finite State Machine for this enemy.
    /// </summary>
    protected IEnemyStateMachine statemachine = new ESMachine();
    public Vector3 TargetPoint { get; set; }
    protected virtual void Init()
    {
        statemachine.ChangeState(new EIdleState(),this);
    }
    protected virtual void UpdateEnemy()
    {
        statemachine.Update(this);
    }
    /// <summary>
    /// Each enemy defines how to move toward a target.
    /// </summary>
    /// <param name="targetPoint">The point to move towards.</param>
    protected abstract void MoveTowardsTarget(Vector3 targetPoint);
    public void TickMovement()
    {
        MoveTowardsTarget(TargetPoint);
    }
}
