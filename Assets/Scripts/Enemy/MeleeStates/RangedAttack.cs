using UnityEngine;

public class RangedAttack : IFSMState<RangedEnemy>
{
    private float timer;
    private float fireRate;
    private Transform player;
    public void Enter(FSMAbstract<RangedEnemy> fsmentity)
    {
        player = GameObject.FindWithTag("Player")?.transform;
        fireRate = 1f;
        timer = 0f;
    }
    public void Update(FSMAbstract<RangedEnemy> fsmentity)
    {
        if (player == null) return;
        float distance = Vector3.Distance(player.position, fsmentity.transform.position);
        if (distance > 11)
        {
            fsmentity.ChangeState(new RangedChase());
            return;
        }
        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            timer = 0f;
            FireProjectile(fsmentity);
        }
    }

    public void Exit(FSMAbstract<RangedEnemy> fsmentity) { }

    private void FireProjectile(FSMAbstract<RangedEnemy> fsmentity)
    {
        Component bulletObj = PoolManager.GetByType(typeof(MissileFSM));
        bulletObj.transform.position = fsmentity.transform.position + Vector3.up;
    }
}
