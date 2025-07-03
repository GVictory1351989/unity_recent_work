using System.Collections.Generic;

public static class GameLoopManager
{
    private static readonly List<IGameSystem> systems = new List<IGameSystem>();
    public static void Register(IGameSystem system)
    {
        if (!systems.Contains(system))
            systems.Add(system);
    }

    public static void Unregister(IGameSystem system)
    {
        systems.Remove(system);
    }

    public static void TickAll()
    {
        foreach (var system in systems)
            system.Tick();
    }
}
