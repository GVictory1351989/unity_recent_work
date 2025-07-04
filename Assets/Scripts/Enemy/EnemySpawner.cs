using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
    public EnemyPresetSO[] presets; // Assign in Inspector or load via Resources
    void Awake()
    {
        int Counter = 0;
        foreach (var preset in presets)
        {
            switch (preset.EnemyType)
            {
                case EnemyType.Melee:
                   var meleelist = PoolBehavior.Instance.AddList<MeleeEnemy>(preset.VisualPreset, preset.SpwnAmount);
                    foreach (MeleeEnemy obj in meleelist)
                    {
                        obj.SetEntityID(nameof(MeleeEnemy), ++Counter);
                        obj.SetEntityConfigSO(preset.Weapon);
                    }
                    break;
                case EnemyType.Ranged:
                    var rangedlist = PoolBehavior.Instance.AddList<RangedEnemy>(preset.VisualPreset,preset.SpwnAmount);
                    foreach (RangedEnemy obj in rangedlist)
                    {
                        obj.SetEntityID(nameof(RangedEnemy), ++Counter);
                        obj.SetEntityConfigSO(preset.Weapon);
                    }
                    break;
                case EnemyType.Explode:
                    var explodelist = PoolBehavior.Instance.AddList<ExplodedEnemy>(preset.VisualPreset, preset.SpwnAmount);
                    foreach (ExplodedEnemy obj in explodelist)
                    {
                        obj.SetEntityID(nameof(ExplodedEnemy), ++Counter);
                        obj.SetEntityConfigSO(preset.Weapon);
                    }
                    break;
            }
        }
    }

    public void Spawn(EnemyPresetSO preset)
    {
        switch (preset.EnemyType)
        {
            case EnemyType.Melee:
                var melee = PoolBehavior.Instance.Get<MeleeEnemy>();
                melee.transform.position = transform.position;
                break;

            case EnemyType.Ranged:
                var ranged = PoolBehavior.Instance.Get<RangedEnemy>();
                ranged.transform.position = transform.position;
                break;

            case EnemyType.Explode:
                var exploder = PoolBehavior.Instance.Get<ExplodedEnemy>();
                exploder.transform.position = transform.position;
                break;
        }
    }
}

