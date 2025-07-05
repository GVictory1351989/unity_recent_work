using UnityEngine;

// This is a generic FSM base class.
// It is used for all enemies who follow FSM (Finite State Machine) behavior.
public abstract class FSMAbstract<T> : MonoBehaviour, IGameSystem, IDamagable
                                       where T : FSMAbstract<T>
{
    private readonly float tickRate = 0.1f; // How often the FSM should update (every 0.1 second)

    private bool isActiveFSM = false;       // Is FSM active now?
    private float lastTick;                 // Time when last update was called
    public static int IDCounter;            // Global counter for assigning unique IDs
    public EntityId EntityId { get; private set; } // Unique ID for this enemy

    private IFSMState<T> currentState;      // Current running state like Idle, Chase, etc.

    // Child class must return starting state like Idle
    protected abstract IFSMState<T> GetInitialState();

    // Set unique ID for this entity
    // Make for ECS mean i think this pattern goes to ECS like 
    // So in ecs make component and write inside that and behavior take input from that 
    //but that takes too much time 
    public void SetEntityID(string type, int id)
    {
        EntityId = new EntityId(type, id);
    }

    // Initialize FSM with first state
    protected virtual void Init(IFSMState<T> initialState)
    {
        currentState = initialState;
        currentState.Enter((T)this); // Call Enter() of the state
        isActiveFSM = true;
    }

    // Change to a new state (like from Idle to Attack)
    public void ChangeState(IFSMState<T> newState)
    {
        currentState?.Exit((T)this);     // Exit current state
        currentState = newState;
        currentState?.Enter((T)this);    // Enter new state
    }

    // This function is called repeatedly every few seconds by GameLoop
    public void Tick(float nowTime)
    {
        if (!isActiveFSM) return; // Do nothing if FSM not active
        if (nowTime - lastTick >= tickRate)
        {
            lastTick = nowTime;
            currentState.Update(this); // Call the Update() of current state
        }
    }

    // When object is enabled (spawned), register to GameLoop and subscribe to events
    protected virtual void OnEnable()
    {
        Init(GetInitialState()); // Start FSM with first state
        GameLoopManager.Register(this); // Add this FSM to GameLoop ticking
        EventManager.Subscribe<HitEvent>(OnHitted); // Listen to hit events
    }

    // When enemy is hit (bullet or other), this function is called
    private void OnHitted(object sender, GameEvent<HitEvent> evt)
    {
        if (evt.Data != null)
        {
            if (evt.Data.HittedObject == gameObject) // Check if hit is for this object
            {
                FSMHitted(); // Call hit handler
            }
        }
    }

    // What happens when this object is hit (override in child class)
    public virtual void FSMHitted()
    {
        // Empty by default — child will write logic
    }

    // When object is disabled (killed or hidden), remove from loop and unsubscribe
    protected virtual void OnDisable()
    {
        GameLoopManager.Unregister(this);
        EventManager.Unsubscribe<HitEvent>(OnHitted);
    }
}
