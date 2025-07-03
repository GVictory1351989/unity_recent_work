using UnityEngine;
/// <summary>
/// Generic FSM State initially 
/// mean modify this for flexible more states addon 
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class FSMAbstract<T> : MonoBehaviour , IGameSystem 
                                       where T : FSMAbstract<T>
{
    private bool isActiveFSM = false;
    private float lastTick;
    private readonly float tickRate = 0.1f;
    public int ID => GetInstanceID();
    private IFSMState<T> currentState;
    protected abstract IFSMState<T> GetInitialState();

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
    public void Tick()
    {
        if (!isActiveFSM) return;

        if (Time.time - lastTick >= tickRate)
        {
            lastTick = Time.time;
            currentState.Update(this);
        }
    }
    protected virtual void OnEnable()
    {
        Init(GetInitialState());
        GameLoopManager.Register(this);
    }

    protected virtual void OnDisable()
    {
        GameLoopManager.Unregister(this);
    }

}
