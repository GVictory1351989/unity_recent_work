// Now make a interface for enemy system 
// enter state 
// update state 
// end state 
public interface IEnemyStateMachine
{
    /// <summary>
    /// When enter a some idle state 
    /// </summary>
    /// <param name="enemy"></param>
    void Enter(Enemy enemy);
    /// <summary>
    /// changes in state in update duration 
    /// </summary>
    /// <param name="enemy"></param>
    void Update(Enemy enemy);
    /// <summary>
    /// When exist state from any state 
    /// </summary>
    /// <param name="enemy"></param>
    void Exit(Enemy enemy);
}