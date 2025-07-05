using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour
{
    [Header("Wave Settings")]
    public float delayBetweenWaves = 5f;
    public int totalWaves = 5;

    [Header("Spawn Counts Per Wave")]
    public int meleeCount = 3;
    public int rangedCount = 2;
    public int explodeCount = 1;

    [Header("Spawn Range")]
    public float spawnRadius = 10f;

    private Transform player;
    private int currentWave = 0;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        if (player == null)
        {
            return;
        }

        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(5f); // After 5 second start 
        while (currentWave < totalWaves)
        {
            currentWave++;
            SpawnEnemies(EnemyType.Melee, meleeCount);
            SpawnEnemies(EnemyType.Ranged, rangedCount);
            SpawnEnemies(EnemyType.Explode, explodeCount);
            yield return new WaitForSeconds(delayBetweenWaves);
        }
    }

    private void SpawnEnemies(EnemyType type, int count)
    {
        System.Type resolvedType = GetComponentTypeFromEnemyType(type);
        for (int i = 0; i < count; i++)
        {
            Component obj = PoolManager.GetByType(resolvedType);
            Vector3 spawnPos = GetSpawnPositionAroundPlayer();
            obj.transform.position = spawnPos;
            obj.transform.rotation = Quaternion.identity;
            obj.gameObject.SetActive(true);

        }
    }

    private System.Type GetComponentTypeFromEnemyType(EnemyType type)
    {
        return type switch
        {
            EnemyType.Melee => typeof(MeleeEnemy),
            EnemyType.Ranged => typeof(RangedEnemy),
            EnemyType.Explode => typeof(ExplodedEnemy),
            _ => typeof(MeleeEnemy)
        };
    }

    private Vector3 GetSpawnPositionAroundPlayer()
    {
        Vector2 offset = Random.insideUnitCircle.normalized * spawnRadius;
        return player.position + new Vector3(offset.x, 0, offset.y);
    }
}
