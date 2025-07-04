
public interface IFSMState<T> where T : FSMAbstract<T>
{
    void Enter(FSMAbstract<T> fsmentity);
    void Exit(FSMAbstract<T> fsmentity);
    void Update(FSMAbstract<T> fsmentity);
}