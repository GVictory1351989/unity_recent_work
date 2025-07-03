using UnityEngine;
/// <summary>
/// Base abstract class for all enemies.
/// </summary>
public abstract class Enemy : MonoBehaviour , IGameSystem
{
    /// <summary>
    /// suppose bullet fire or any trajecctile 
    /// then by span change calculation of that 
    /// </summary>
    public int ID => GetInstanceID(); // id attach 
    /// <summary>
    /// Finite State Machine for this enemy.
    /// </summary>
    protected IEnemyStateMachine statemachine = new ESMachine();
    /// <summary>
    /// TargetPoint for move towards 
    /// </summary>
    public Vector3 TargetPoint { get; set; }
    /// <summary>
    /// Init
    /// </summary>
    protected virtual void Init()
    {
        ChangeState(new EIdleState());
    }
    void OnEnable()
    {
        Init();
        GameLoopManager.Register(this);  // Sirf jab object Active hoga
    }
    protected virtual void UpdateEnemy()
    {
        statemachine.Update(this);
    }
    public void ChangeState(IEnemyState currentState)
    {
        statemachine.ChangeState(currentState, this);
    }
    private float lastTick;
    public void Tick()
    {
        // lot of enemies run then 
        // threshold make 
        if (Time.time - lastTick > 0.1f)
        {
            lastTick = Time.time;
            UpdateEnemy();                  // Update Enemy State 
        }
    }
    public virtual void MoveTowardsTarget(Vector3 targetPoint) { }
    void OnDisable()
    {
        GameLoopManager.Unregister(this);  // Jab object deactivate ho
    }

}
