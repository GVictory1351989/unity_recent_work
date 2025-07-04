using System.Collections.Generic;

public static class GameLoopManager
{
    private static readonly List<IGameSystem> systems = new List<IGameSystem>();
    public static void Register(IGameSystem system)
    {
        if (system != null && !systems.Contains(system))
            systems.Add(system);
    }

    public static void Unregister(IGameSystem system)
    {
        systems.Remove(system);
    }

    public static void TickAll()
    {
        float now = UnityEngine.Time.time;
        for (int i = systems.Count - 1; i >= 0; i--)
        {
            if (systems[i] == null)
            {
                systems.RemoveAt(i); 
                continue;
            }
            systems[i].Tick(now);
        }
    }
}
