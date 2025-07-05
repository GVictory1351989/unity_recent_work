using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface for any object that can take damage.
/// Classes that implement this interface must define how they handle being hit (e.g., lose health, play effects, etc.).
/// This is useful for making damage systems flexible and reusable across different types of objects (enemies, players, destructibles, etc.).
/// </summary>
public interface IDamagable
{
    /// <summary>
    /// This method is called when the object takes damage.
    /// Implement this method to define what happens when the object is hit (e.g., reduce health, play sound, die).
    /// </summary>
    void FSMHitted();
}
