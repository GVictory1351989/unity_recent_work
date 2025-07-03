using UnityEngine;
/// <summary>
/// Make an enemy abstraction class 
/// Enemy have a state machine 
/// Move Towards Target
/// Each enemy have there state machine by state 
/// he work proper
/// </summary>
public abstract class Enemy 
{
    /// <summary>
    /// make an object of Enemy State Machine
    /// </summary>
    protected IEnemyStateMachine statemachine = new ESMachine();
    /// <summary>
    /// Move Towards Target by target point 
    /// </summary>
    /// <param name="targetPoint"></param>
    protected abstract void MoveTowardsTarget(Vector3 targetPoint);
}
