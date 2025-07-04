using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Enemy Preset")]
public class EnemyPresetSO : ScriptableObject
{
    public EnemyType EnemyType;
    public WeaponConfigSO Weapon;
    public GameObject VisualPreset;
    public float StayTime;
    public int Health;
    public float FireRate;
    public int SpwnAmount = 20;
}
