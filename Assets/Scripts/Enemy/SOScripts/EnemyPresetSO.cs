using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Enemy Preset")]
public class EnemyPresetSO : EntityStatsBaseSO
{
    public EnemyType EnemyType;
    public WeaponConfigSO Weapon;
    public GameObject VisualPreset;
    public float FireRate;
    public int SpwnAmount = 20;
}
