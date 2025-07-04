using UnityEngine;

public enum WeaponType { Melee, Bullet, ArcProjectile, Explode }

[CreateAssetMenu(menuName = "FSM/Weapon Config")]
public class WeaponConfigSO : ScriptableObject
{
    public WeaponType WeaponType;
    public GameObject ProjectilePrefab;
    public float Cooldown = 1.5f;
    public float Range = 5f;
    public float Damage = 10f;
    public float FireRate = 0.3f;
    public float StayTime = 3f;
    public int Health = 100;
}
