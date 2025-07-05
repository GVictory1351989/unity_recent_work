using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface for any game system that needs to perform logic regularly (every frame or tick).
/// This is similar to Unity's Update() method, but allows centralized or manual control over system updates.
/// Examples: AI system, Projectile system, Spawn system, etc.
/// </summary>
public interface IGameSystem
{
    /// <summary>
    /// Called every frame (or fixed interval) to update the system's logic.
    /// Equivalent to Unity's MonoBehaviour.Update(), but decoupled from Unity's component model.
    /// </summary>
    /// <param name="time">Delta time or fixed time step passed in by the system runner.</param>
    void Tick(float time);
}
