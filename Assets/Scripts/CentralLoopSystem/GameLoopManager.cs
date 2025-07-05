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
        systems.RemoveAll(s => s == null);
        for (int i = 0; i < systems.Count; i++)
        {
            var system = systems[i];
            if (system == null) continue;
            system.Tick(now);
        }
    }

}
