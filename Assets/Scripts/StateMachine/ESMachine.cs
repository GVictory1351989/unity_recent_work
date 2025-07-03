/// <summary>
/// This is the enemy's State Machine.
/// It controls which state enemy is in now (like Idle, Chase, Attack).
/// </summary>
public class ESMachine : IEnemyStateMachine
{
    /// <summary>
    /// This is the current state (example: IdleState, ChaseState).
    /// </summary>
    private IEnemyState currentState;

    /// <summary>
    /// This method changes the state.
    /// First it exits the old state,
    /// then enters the new state.
    /// </summary>
    /// <param name="newState">The new state we want</param>
    /// <param name="enemy">The enemy object</param>
    public void ChangeState(IEnemyState newState, Enemy enemy)
    {
        currentState?.Exit(enemy);        // exit from old state
        currentState = newState;          // set new state
        currentState?.Enter(enemy);       // enter into new state
    }

    /// <summary>
    /// This method is called every frame.
    /// It updates the current state.
    /// Example: moving, chasing, checking distance.
    /// </summary>
    /// <param name="enemy">The enemy object</param>
    public void Update(Enemy enemy)
    {
        currentState?.Update(enemy);      // update the current state
    }
}
