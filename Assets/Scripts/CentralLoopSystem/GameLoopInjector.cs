using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.LowLevel;
using UnityEngine.PlayerLoop;

/// <summary>
/// This class adds (injects) our own custom loop inside Unity's internal PlayerLoop.
/// I first time use this , I never work before but thanks for this 
/// I use here first time use in interview this PlayerLoop Inject
/// without using MonoBehaviour's Update().
/// </summary>
public class GameLoopInjector
{
    /// <summary>
    /// This method runs automatically after scene is loaded.
    /// It adds our custom loop (GameLoopManager.TickAll) into Unity's Update phase.
    /// </summary>
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void InjectCustomLoop()
    {
        // Get Unity's current player loop system (which controls all Update calls internally)
        PlayerLoopSystem playerLoop = PlayerLoop.GetCurrentPlayerLoop();

        // Make our custom loop system
        PlayerLoopSystem customLoop = new PlayerLoopSystem
        {
            type = typeof(GameLoopManager), // just for naming/debugging
            updateDelegate = GameLoopManager.TickAll // method to call every frame
        };

        // Insert our custom loop into Unity's Update section
        InsertIntoUpdateLoop(ref playerLoop, typeof(Update), customLoop);

        // Set the modified loop back to Unity so it will start using it
        PlayerLoop.SetPlayerLoop(playerLoop);
    }

    /// <summary>
    /// This method finds the Update phase in Unity's internal PlayerLoop,
    /// and adds our custom system into it.
    /// </summary>
    /// <param name="loop">Unity's player loop</param>
    /// <param name="phase">Where to insert (like Update, FixedUpdate...)</param>
    /// <param name="system">Our custom loop system</param>
    static void InsertIntoUpdateLoop(ref PlayerLoopSystem loop, Type phase, PlayerLoopSystem system)
    {
        for (int i = 0; i < loop.subSystemList.Length; i++)
        {
            if (loop.subSystemList[i].type == phase)
            {
                // Get existing subsystems inside Update
                var subs = new List<PlayerLoopSystem>(loop.subSystemList[i].subSystemList);

                // Add our system at the top so it runs before others
                subs.Insert(0, system);

                // Set updated list back
                loop.subSystemList[i].subSystemList = subs.ToArray();
                return;
            }
        }
    }
}
