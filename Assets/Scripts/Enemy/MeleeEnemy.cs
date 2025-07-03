using UnityEngine;
public class MeleeEnemy : FSMAbstract<MeleeEnemy>
{
    public Vector3 TargetPoint { get; set; }
    protected override IFSMState<MeleeEnemy> GetInitialState()
    {
        return new MeleeIdleState();
    }
}

