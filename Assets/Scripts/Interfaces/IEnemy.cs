using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface for all enemy types in the game (e.g., Melee, Ranged, Exploding).
/// Defines shared properties and methods that every enemy must have or implement.
/// Useful for writing systems that work with any kind of enemy without needing to know their specific class.
/// </summary>
public interface IEnemy
{
    /// <summary>
    /// The current target position the enemy is moving or aiming toward.
    /// </summary>
    Vector3 TargetPoint { get; set; }

    /// <summary>
    /// The current health value of the enemy.
    /// </summary>
    int Health { get; set; }

    /// <summary>
    /// How frequently the enemy can shoot or attack (shots per second or attacks per second).
    /// </summary>
    float FireRate { get; set; }

    /// <summary>
    /// How long the enemy stays in one position before moving again (in seconds).
    /// </summary>
    float StayTime { get; set; }

    /// <summary>
    /// The type of the enemy (e.g., Melee, Ranged, Exploding).
    /// Used for identification or logic branching.
    /// </summary>
    EnemyType EnemyType { get; }

    /// <summary>
    /// Sets up the enemy's configuration using values from an external data source (like a ScriptableObject).
    /// Called when the enemy is spawned or reset.
    /// </summary>
    /// <param name="range">Avoidance or awareness radius.</param>
    /// <param name="cooldown">Attack cooldown time in seconds.</param>
    /// <param name="damage">Amount of damage this enemy deals.</param>
    /// <param name="staytime">How long the enemy stays in one spot before moving.</param>
    /// <param name="health">Starting health value.</param>
    /// <param name="speed">Movement speed.</param>
    /// <param name="rotateSpeed">Rotation speed towards target.</param>
    void SetEntityConfigSO(float range,
                           float cooldown,
                           float damage,
                           float staytime,
                           int health,
                           float speed,
                           float rotateSpeed);
}
