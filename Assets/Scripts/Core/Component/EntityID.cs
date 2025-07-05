using System;

/// <summary>
/// A lightweight, read-only structure that represents a unique identifier for any entity in the game.
/// Combines a `Type` (like "Enemy", "Player", "Item") and an `Id` (like 1, 2, 3...) to ensure uniqueness.
/// Useful for tracking and comparing entities without relying on GameObject references.
/// </summary>
public readonly struct EntityId
{
    // The category or kind of the entity (e.g., "Enemy", "NPC", "Item")
    public readonly string Type;
    // A unique numerical ID for the entity within its type
    public readonly int Id;
    /// <summary>
    /// Constructor to create an EntityId from type and id.
    /// </summary>
    public EntityId(string type, int id)
    {
        Type = type;
        Id = id;
    }
    /// <summary>
    /// Returns the ID as a string, combining type and number (e.g., "Enemy5").
    /// </summary>
    public override string ToString() => Type + Id;
    /// <summary>
    /// Generates a hash code based on both Type and Id.
    /// This is important for using EntityId as a key in dictionaries or hash sets.
    /// </summary>
    public override int GetHashCode() => HashCode.Combine(Type, Id);
    /// <summary>
    /// Checks if another object is an EntityId and compares both the type and id for equality.
    /// </summary>
    public override bool Equals(object obj) =>
        obj is EntityId other && other.Type == Type && other.Id == Id;
}
