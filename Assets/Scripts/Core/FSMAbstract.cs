using UnityEngine;
/// <summary>
/// Generic FSM State initially 
/// mean modify this for flexible more states addon 
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class FSMAbstract<T> : MonoBehaviour , IGameSystem,IDamagable
                                       where T : FSMAbstract<T>
{
    private readonly float tickRate = 0.1f;

    private bool isActiveFSM = false;
    private float lastTick;
    public static int IDCounter;
    public EntityId EntityId { get; private set; }
    private IFSMState<T> currentState;
    protected abstract IFSMState<T> GetInitialState();
    public void SetEntityID(string type, int id)
    {
        EntityId = new EntityId(type, id);
    }
    protected virtual void Init(IFSMState<T> initialState)
    {
        currentState = initialState;
        currentState.Enter((T)this);
        isActiveFSM = true;
    }
    public void ChangeState(IFSMState<T> newState)
    {
        currentState?.Exit((T)this);
        currentState = newState;
        currentState?.Enter((T)this);
    }
    public void Tick(float nowTime)
    {
        if (!isActiveFSM) return;
        if (nowTime - lastTick >= tickRate)
        {
            lastTick = nowTime;
            currentState.Update(this);
        }
    }
    protected virtual void OnEnable()
    {
        Init(GetInitialState());
        GameLoopManager.Register(this);
        EventManager.Subscribe<HitEvent>(OnHitted);
    }
    private void OnHitted(object sender, GameEvent<HitEvent> evt)
    {
        if (evt.Data != null)
        {
            if (evt.Data.HittedObject==gameObject)
            {
                FSMHitted();
            }
        }
    }
    public virtual void FSMHitted()
    {
    }
    protected virtual void OnDisable()
    {
        GameLoopManager.Unregister(this);
        EventManager.Unsubscribe<HitEvent>( OnHitted);
    }

}
/// <summary>
/// For Hit Event Tract 
/// </summary>
public class HitEvent
{
    public GameObject HittedObject;

}