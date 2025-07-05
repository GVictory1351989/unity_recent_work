using System.Collections;
using UnityEngine;
public class MissileFSM : EnemyBase<MissileFSM>
{
    public Transform Player { get; private set; }
    public override EnemyType EnemyType => EnemyType.None;

    protected override IFSMState<MissileFSM> GetInitialState()
    {
        Player = GameObject.FindGameObjectWithTag("Player")?.transform;
        return new MissileFly();
    }
}
