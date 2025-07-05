using UnityEngine;

public enum WeaponType { Melee, Bullet, ArcProjectile, Explode }
[CreateAssetMenu(menuName = "FSM/Weapon Config")]
public class WeaponConfigSO : EntityStatsBaseSO
{
    public WeaponType WeaponType;
    public EnemyType EnemyType;
    public GameObject ProjectilePrefab;
    public float Cooldown = 1.5f;
    public float Range = 5f;
    public float Damage = 10f;
    public float FireRate = 0.3f;
    public int SpwnAmount = 10;
}
