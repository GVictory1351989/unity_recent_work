using System;
using System.Collections.Generic;
public static class ComponentStorage
{
    public static Dictionary<(string, int), Dictionary<Type, object>> AllEntities = new();
    public static bool TryGetComponent<T>((string, int) entityId, out T result) where T : struct
    {
        result = default;
        if (AllEntities.TryGetValue(entityId, out var dict) &&
            dict.TryGetValue(typeof(T), out var obj) &&
            obj is T casted)
        {
            result = casted;
            return true;
        }
        return false;
    }

    public static void SetComponent<T>((string, int) entityId, T component) where T : struct
    {
        if (!AllEntities.TryGetValue(entityId, out var dict))
        {
            dict = new();
            AllEntities[entityId] = dict;
        }
        dict[typeof(T)] = component;
    }
}
