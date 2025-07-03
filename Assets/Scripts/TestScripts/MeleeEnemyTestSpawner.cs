using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyTestSpawner : MonoBehaviour
{
    public GameObject meleeEnemyPrefab;
    public Transform player;
    void Start()
    {
        GameObject enemyGO = Instantiate(meleeEnemyPrefab, transform.position, Quaternion.identity);
        var enemy = enemyGO.GetComponent<MeleeEnemy>();
        enemy.TargetPoint = player.position;
    }
}
