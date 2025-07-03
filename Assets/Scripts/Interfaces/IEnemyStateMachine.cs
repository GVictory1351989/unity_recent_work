/// <summary>
/// This interface is for enemy state system.
/// It tells what a state machine must do:
/// - It must change enemy state.
/// - It must update current state every frame.
///
///  Why we need this:
/// - So we can use different types of state machines in future.
/// - Enemy will not depend on one fixed class.
/// - It makes code clean and easy to change.
///
/// Example:
/// Enemy can be in Idle, Chase, Attack, or Die state.
/// This system helps to switch between those states.
/// </summary>
public interface IEnemyStateMachine
{
    /// <summary>
    /// This will change the current state of enemy to new one.
    /// </summary>
    /// <param name="newState">New state to enter</param>
    /// <param name="enemy">Enemy who is changing state</param>
    void ChangeState(IEnemyState newState, Enemy enemy);

    /// <summary>
    /// This will update current state logic (like move, chase etc).
    /// Called every frame or tick.
    /// </summary>
    /// <param name="enemy">Enemy to update</param>
    void Update(Enemy enemy);
}
