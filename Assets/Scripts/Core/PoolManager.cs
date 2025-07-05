using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A static PoolManager class that manages object pooling for reusable GameObjects.
/// Helps improve performance by reusing inactive objects instead of creating/destroying them frequently.
/// </summary>
public static class PoolManager
{
    // Maps each type to a queue of inactive GameObjects (the actual pool)
    private static Dictionary<Type, Queue<GameObject>> poolObjects = new();

    // Maps each type to its corresponding prefab for instantiation
    private static Dictionary<Type, GameObject> prefabMap = new();

    // A delegate function to retrieve a component by its type
    public static Func<Type, Component> GetByType;

    // Static constructor ensures delegate initialization when the class is first accessed
    static PoolManager()
    {
        InitializeDelegates();
    }

    /// <summary>
    /// Initializes the GetByType delegate to return pooled components based on their type.
    /// Useful for retrieving pooled enemies (Melee, Ranged, etc.) generically.
    /// </summary>
    public static void InitializeDelegates()
    {
        GetByType = (type) =>
        {
            if (type == typeof(MeleeEnemy)) return Get<MeleeEnemy>();
            if (type == typeof(RangedEnemy)) return Get<RangedEnemy>();
            if (type == typeof(ExplodedEnemy)) return Get<ExplodedEnemy>();
            if (type == typeof(BulletFSM)) return Get<BulletFSM>();
            if (type == typeof(MissileFSM)) return Get<MissileFSM>();
            return null;
        };
    }

    /// <summary>
    /// Checks if a pool already exists for the given type.
    /// </summary>
    public static bool HasPool(Type type) => poolObjects.ContainsKey(type);

    /// <summary>
    /// Adds a pool of inactive GameObjects of the specified type using a prefab.
    /// </summary>
    /// <typeparam name="T">The component type on the prefab (e.g., MeleeEnemy).</typeparam>
    /// <param name="prefab">The GameObject prefab to clone.</param>
    /// <param name="count">How many instances to pre-instantiate.</param>
    public static void Add<T>(GameObject prefab, int count = 10) where T : Component
    {
        Type type = typeof(T);

        // Only add pool if it doesn't exist already
        if (!poolObjects.ContainsKey(type))
        {
            poolObjects[type] = new Queue<GameObject>();
            prefabMap[type] = prefab;

            // Instantiate and store 'count' objects in the pool
            for (int i = 0; i < count; i++)
            {
                GameObject obj = MonoBehaviour.Instantiate(prefab);
                obj.SetActive(false); // Initially inactive
                poolObjects[type].Enqueue(obj);
            }
        }
    }

    /// <summary>
    /// Same as Add(), but also returns a list of the components added.
    /// Useful when you want to configure them after creation.
    /// </summary>
    public static List<T> AddList<T>(GameObject prefab, int count = 10) where T : Component
    {
        Type type = typeof(T);
        List<T> components = new List<T>();

        if (!poolObjects.ContainsKey(type))
        {
            poolObjects[type] = new Queue<GameObject>();
            prefabMap[type] = prefab;

            for (int i = 0; i < count; i++)
            {
                GameObject obj = MonoBehaviour.Instantiate(prefab);
                obj.SetActive(false);

                // Attach component T if not present
                T component = obj.AddComponent<T>();
                components.Add(component);

                poolObjects[type].Enqueue(obj);
            }
        }

        return components;
    }

    /// <summary>
    /// Retrieves (activates) a GameObject of type T from the pool.
    /// </summary>
    private static T Get<T>() where T : Component
    {
        Type type = typeof(T);
        Queue<GameObject> queue = poolObjects[type];

        // Dequeue (take out) one object from the pool
        GameObject obj = queue.Dequeue();
        obj.SetActive(true); // Activate it

        return obj.GetComponent<T>(); // Return the requested component
    }

    /// <summary>
    /// Returns all currently inactive pooled GameObjects of a specific type.
    /// </summary>
    public static IEnumerable<GameObject> GetAllInactiveObjectsOfType<T>() where T : Component
    {
        Type type = typeof(T);

        if (poolObjects.TryGetValue(type, out var queue))
        {
            return queue; // Return the queue as IEnumerable
        }

        return new List<GameObject>(); // Return empty list if type doesn't exist
    }

    /// <summary>
    /// Returns an object back to the pool and deactivates it.
    /// </summary>
    public static void ReturnToPool<T>(T obj) where T : Component
    {
        Type type = typeof(T);

        // Deactivate the object
        obj.gameObject.SetActive(false);

        // Ensure there's a pool for this type
        if (!poolObjects.ContainsKey(type))
        {
            poolObjects[type] = new Queue<GameObject>();
        }

        // Add it back to the pool
        poolObjects[type].Enqueue(obj.gameObject);
    }
}
