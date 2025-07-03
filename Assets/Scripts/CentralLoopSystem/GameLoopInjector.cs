using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.LowLevel;
using UnityEngine.PlayerLoop;

public class GameLoopInjector
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void InjectCustomLoop()
    {
        PlayerLoopSystem playerLoop = PlayerLoop.GetCurrentPlayerLoop();
        PlayerLoopSystem customLoop = new PlayerLoopSystem
        {
            type = typeof(GameLoopManager),
            updateDelegate = GameLoopManager.TickAll
        };

        InsertIntoUpdateLoop(ref playerLoop, typeof(Update), customLoop);
        PlayerLoop.SetPlayerLoop(playerLoop);
    }

    static void InsertIntoUpdateLoop(ref PlayerLoopSystem loop, Type phase, PlayerLoopSystem system)
    {
        for (int i = 0; i < loop.subSystemList.Length; i++)
        {
            if (loop.subSystemList[i].type == phase)
            {
                var subs = new List<PlayerLoopSystem>(loop.subSystemList[i].subSystemList);
                subs.Insert(0, system); // insert at top
                loop.subSystemList[i].subSystemList = subs.ToArray();
                return;
            }
        }
    }
}
