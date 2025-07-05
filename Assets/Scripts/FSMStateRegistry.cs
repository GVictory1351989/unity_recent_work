using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

public static class FSMStateRegistry<T> where T : FSMAbstract<T>
{
    private static readonly Dictionary<string, Type> stateMap = new();
    private static Type initialStateType;
    static FSMStateRegistry()
    {
        RegisterAllStates();
    }
    private static void RegisterAllStates()
    {
        var allTypes = Assembly.GetAssembly(typeof(T)).GetTypes();
        foreach (var type in allTypes)
        {
            if (!typeof(IFSMState<T>).IsAssignableFrom(type)) continue;
            var attr = type.GetCustomAttribute<FSMStateAttribute>();
            if (attr != null)
            {
                stateMap[attr.Name] = type;
                if (attr.IsInitial)
                    initialStateType = type;
            }
        }
    }

    public static Type GetStateType(string name)
    {
        if (stateMap.TryGetValue(name, out var type))
            return type;
        return null;
    }

    public static IFSMState<T> GetInitialStateInstance()
    {
        if (initialStateType != null)
            return Activator.CreateInstance(initialStateType) as IFSMState<T>;
        return null;
    }
}
