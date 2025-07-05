using System;
public readonly struct EntityId
{
    public readonly string Type;
    public readonly int Id;
    public EntityId(string type, int id)
    {
        Type = type;
        Id = id;
    }
    public override string ToString() => Type + Id;
    public override int GetHashCode() => HashCode.Combine(Type, Id);
    public override bool Equals(object obj) => obj is EntityId other && other.Type == Type && other.Id == Id;
}

