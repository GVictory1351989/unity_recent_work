using System.Collections;
using UnityEngine;

public class BulletFSM : EnemyBase<BulletFSM>
{
    public Transform Player { get; private set; }
    public override EnemyType EnemyType => EnemyType.None;
    protected override IFSMState<BulletFSM> GetInitialState()
    {
        Player = GameObject.FindGameObjectWithTag("Player")?.transform;
        return Player == null ? new BulletHit() : new BulletFly();
    }
}
