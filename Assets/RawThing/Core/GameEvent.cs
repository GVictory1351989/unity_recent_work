using System;
/// <summary>
/// This class is used to make event with data.
/// You can send any data with this event and also give callback if needed.
/// </summary>
/// <typeparam name="T">Type of data you want to send in event</typeparam>
public class GameEvent<T> : EventArgs
{
    /// <summary>
    /// The data value which will go with event.
    /// </summary>
    public T Data { get; }

    private readonly Action callback;

    /// <summary>
    /// Make new event with data and optional callback.
    /// If callback is given, it will be called later.
    /// </summary>
    /// <param name="data">The data value to pass</param>
    /// <param name="callback">Optional function to run after event handled</param>
    public GameEvent(T data, Action callback = null)
    {
        Data = data;
        this.callback = callback;
    }

    /// <summary>
    /// This will run the callback function if it is given.
    /// Use when you want to run something after event finish.
    /// </summary>
    public void RaiseCallback()
    {
        callback?.Invoke();
    }
}
