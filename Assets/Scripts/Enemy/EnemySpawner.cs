using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
    public EnemyPresetSO[] presets; // Assign in Inspector or load via Resources
    private int counter = 0; // id assign also 
    void Awake()
    {
        foreach (var preset in presets)
        {
            switch (preset.EnemyType)
            {
                case EnemyType.Melee:
                    SpawnEnemyType<MeleeEnemy>(preset, nameof(MeleeEnemy));
                    break;
                case EnemyType.Ranged:
                    SpawnEnemyType<RangedEnemy>(preset, nameof(RangedEnemy));
                    break;
                case EnemyType.Explode:
                    SpawnEnemyType<ExplodedEnemy>(preset, nameof(ExplodedEnemy));
                    break;
            }
        }
    }
    private void SpawnEnemyType<T>(EnemyPresetSO preset, string entityName) where T : FSMAbstract<T>
    {
        var enemyList = PoolBehavior.Instance.AddList<T>(preset.VisualPreset, preset.SpwnAmount);
        foreach (var enemy in enemyList)
        {
            enemy.SetEntityID(entityName, ++counter);
            if (enemy is IEnemy configurer) // not in base class 
            {
                configurer.SetEntityConfigSO(preset.Weapon); // so now implement in interface 
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

