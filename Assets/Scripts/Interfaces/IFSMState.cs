/// <summary>
/// Interface for defining a state in a Finite State Machine (FSM).
/// Each state (e.g., Idle, Move, Attack, Die) must implement this interface,
/// and define behavior for when the state is entered, updated, or exited.
/// </summary>
/// <typeparam name="T">The type of the FSM controller (usually the enemy or AI component).</typeparam>
public interface IFSMState<T> where T : FSMAbstract<T>
{
    /// <summary>
    /// Called once when the state is first entered.
    /// Used for initialization or triggering animations, etc.
    /// </summary>
    /// <param name="fsmentity">The FSM component controlling this state.</param>
    void Enter(FSMAbstract<T> fsmentity);

    /// <summary>
    /// Called once when the state is exited.
    /// Use this to clean up effects, reset flags, etc.
    /// </summary>
    /// <param name="fsmentity">The FSM component controlling this state.</param>
    void Exit(FSMAbstract<T> fsmentity);

    /// <summary>
    /// Called every frame while the FSM is in this state.
    /// This is where the main behavior of the state goes (e.g., moving, chasing, attacking).
    /// </summary>
    /// <param name="fsmentity">The FSM component controlling this state.</param>
    void Update(FSMAbstract<T> fsmentity);
}
