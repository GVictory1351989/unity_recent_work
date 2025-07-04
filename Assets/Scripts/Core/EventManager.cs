using System;
using System.Collections.Generic;
/// <summary>
/// Make an event manager which handle events base communication 
/// and loose coupling promote top level of cohesion communication 
/// </summary>
public class EventManager 
{
    /// <summary>
    /// Dictionary have delegates 
    /// where multiple methods attach with a single delegate 
    /// </summary>
    private static Dictionary<Type, Delegate> events = new Dictionary<Type, Delegate>();
    /// <summary>
    /// In this method, we are adding a new method (callback) to event list.
    /// So, when event happens, this method will be called.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="callback"></param>
    public static void Subscribe<T>(EventHandler<GameEvent<T>> callback)
    {
        Type eventtype = typeof(T);
        if (events.TryGetValue(eventtype, out var existing))
        {
            events[eventtype] = Delegate.Combine(existing, callback);
        }
        else
            events[eventtype] = callback;
    }
    /// <summary>
    /// This method removes the method (callback) from the event list.
    /// So, when event happens in future, this method will not be called.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="callback"></param>
    public static void Unsubscribe<T>(EventHandler<GameEvent<T>> callback)
    {
        Type eventType = typeof(T);

        if (events.TryGetValue(eventType, out var existing))
        {
            var current = Delegate.Remove(existing, callback);
            if (current == null)
                events.Remove(eventType);
            else
                events[eventType] = current;
        }
    }
    /// <summary>
    ///This method sends(publishes) the event to all subscribed listeners.
    /// All methods that are subscribed to this event type will be called.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="sender"></param>
    /// <param name="evt"></param>
    public static void Publish<T>(object sender, GameEvent<T> evt)
    {
        Type eventType = typeof(T);

        if (events.TryGetValue(eventType, out var del))
        {
            if (del is EventHandler<GameEvent<T>> handler)
            {
                handler.Invoke(sender, evt);
            }
        }
    }

    internal static void Subscribe<T>(object p)
    {
        throw new NotImplementedException();
    }
}