using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
    public WeaponConfigSO[] presets; // Assign in Inspector or load via Resources
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
                case EnemyType.MeleeBullet: 
                    SpawnEnemyType<BulletFSM>(preset, nameof(BulletFSM));
                    break;
                case EnemyType.ProjectileBullet:
                    SpawnEnemyType<MissileFSM>(preset, nameof(MissileFSM));
                    break;
            }
        }
    }
    private void SpawnEnemyType<T>(WeaponConfigSO preset, string entityName ) where T : FSMAbstract<T>
    {
        var enemyList = PoolManager.AddList<T>(preset.ProjectilePrefab, preset.SpwnAmount);
        foreach (var enemy in enemyList)
        {
            enemy.SetEntityID(entityName, ++counter);
            enemy.name = enemy.EntityId.ToString();
           
                if (enemy is IEnemy configurer) // for child make interface and use this 
                {
                    configurer.SetEntityConfigSO(preset.Range,
                                preset.Cooldown,
                                preset.Damage,
                                preset.StayTime,
                                preset.Health,
                                preset.Speed,
                                preset.RotateSpeed);
                }
        }
    }
}

