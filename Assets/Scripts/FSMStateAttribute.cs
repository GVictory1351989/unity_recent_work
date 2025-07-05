using System;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public sealed class FSMStateAttribute : Attribute
{
    /// <summary>
    /// Unique name of the FSM state. Used to identify the state via string.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// If true, this state will be used as the initial state for the FSM.
    /// </summary>
    public bool IsInitial { get; }

    /// <summary>
    /// Marks a class as an FSM State and optionally flags it as the initial state.
    /// </summary>
    /// <param name="name">Unique name for this FSM state (e.g., "Idle", "Chase").</param>
    /// <param name="isInitial">Set true to mark this state as the entry/start state.</param>
    public FSMStateAttribute(string name, bool isInitial = false)
    {
        Name = name;
        IsInitial = isInitial;
    }
}
