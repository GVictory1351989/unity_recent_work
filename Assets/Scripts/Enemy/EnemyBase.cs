using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a base class for all enemy types like Melee, Ranged, Exploded, etc.
/// It contains common logic that all enemies share—such as health, speed, damage, and UI updates (like health bar sliders).
/// It also inherits from a generic FSM (Finite State Machine) system to handle state transitions like moving, attacking, or dying.
/// </summary>
public abstract class EnemyBase<T> : FSMAbstract<T>, IEnemy where T : FSMAbstract<T>
{
    // Position the enemy is trying to move to or attack
    public Vector3 TargetPoint { get; set; }

    // Enemy's current health
    public int Health { get; set; }

    // How frequently the enemy can shoot or attack (shots per second or cooldown between attacks)
    public float FireRate { get; set; }

    // How long the enemy should stay in a position before moving again
    public float StayTime { get; set; }

    // Distance to avoid obstacles or other objects
    public float AvoidRadius { get; set; }

    // Cooldown time between each attack
    public float AttackCooldown { get; set; }

    // Damage this enemy deals
    public float Damage { get; set; }

    // How fast the enemy moves
    public float Speed { get; set; }

    // How fast the enemy can rotate towards its target
    public float RotateSpeed { get; set; }

    // Stores the initial (maximum) health value for resetting and UI updates
    protected int GlobalHealth { get; private set; }

    // Reference to the child "Slider" GameObject used for the health bar
    protected GameObject Slider { get; private set; }

    // Type of enemy; can be overridden by child classes like Melee, Ranged, etc.
    public virtual EnemyType EnemyType => EnemyType.None;

    /// <summary>
    /// Finds and stores the reference to the "Slider" (health bar) UI element.
    /// This should be a child object named "Slider" under the enemy GameObject.
    /// </summary>
    protected void InitSlider()
    {
        Slider = transform.Find("Slider")?.gameObject;
    }

    /// <summary>
    /// Initializes or sets up this enemy's configuration (called when spawning or resetting).
    /// These values typically come from a ScriptableObject (EnemyConfigSO).
    /// </summary>
    public void SetEntityConfigSO(float range,
                                   float cooldown,
                                   float damage,
                                   float staytime,
                                   int health,
                                   float speed,
                                   float rotateSpeed)
    {
        AvoidRadius = range;
        AttackCooldown = cooldown;
        Damage = damage;
        StayTime = staytime;
        Health = health;
        Speed = speed;
        RotateSpeed = rotateSpeed;
        GlobalHealth = health; // Save max health for future use (e.g. UI)
    }

    /// <summary>
    /// This method is called whenever the enemy gets hit.
    /// It reduces the health and updates the UI slider (health bar).
    /// If health reaches zero, the enemy is "killed" and an event is published to notify the system.
    /// </summary>
    public override void FSMHitted()
    {
        Health--; // Take damage (reduce health by 1)

        // If a health slider UI exists, update its scale to reflect the new health
        if (Slider != null)
        {
            float xScale = Utils.PercentageScale(Health, GlobalHealth); // Calculate percentage (0 to 1)
            Vector3 scale = Slider.transform.localScale;
            scale.x = xScale;
            Slider.transform.localScale = scale;
        }

        // If health is 0 or less, trigger death event and reset health
        if (Health <= 0)
        {
            // Publish a "death" event to notify game systems
            EventManager.Publish(null, new GameEvent<Component>(this));

            // Reset health back to full (used in pooling/reusing enemies)
            Health = GlobalHealth;

            // Also reset the slider scale to full
            if (Slider != null)
                Slider.transform.localScale = Vector3.one;
        }
    }
}
