using System.Collections.Generic;

public static class GameLoopManager
{
    private static readonly List<IGameSystem> systems = new List<IGameSystem>();
    public static void Register(IGameSystem system)
    {
        // Optional: use HashSet to avoid O(n) Contains
        if (!systems.Contains(system))
            systems.Add(system);
    }

    public static void Unregister(IGameSystem system)
    {
        systems.Remove(system);
    }

    public static void TickAll()
    {
        float now = UnityEngine.Time.time;
        int count = systems.Count;

        for (int i = 0; i < count; i++)
        {
            systems[i].Tick(now); // Use shared time param (less Time.time calls)
        }
    }
}
