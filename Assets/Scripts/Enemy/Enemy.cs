using UnityEngine;
/// <summary>
/// Base abstract class for all enemies.
/// </summary>
public abstract class Enemy
{
    /// <summary>
    /// Finite State Machine for this enemy.
    /// </summary>
    protected IEnemyStateMachine statemachine = new ESMachine();
    /// <summary>
    /// Internal storage of enemy position.
    /// </summary>
    private Vector3 position;
    /// <summary>
    /// Position property to get/set enemy position.
    /// </summary>
    public Vector3 Position
    {
        get => position;
        set => position = value;
    }
    /// <summary>
    /// Each enemy defines how to move toward a target.
    /// </summary>
    /// <param name="targetPoint">The point to move towards.</param>
    protected abstract void MoveTowardsTarget(Vector3 targetPoint);
}
