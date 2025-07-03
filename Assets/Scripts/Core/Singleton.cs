/// <summary>
/// Creates a generic singleton class for any reference type.
/// Only one instance of type <typeparamref name="T"/> will be
/// created and shared globally.
/// </summary>
/// <typeparam name="T">
/// The class type which should behave like a singleton. 
/// It must have a public parameterless constructor.
/// </typeparam>
public class Singleton<T> where T : class ,new()
{
    private static readonly  T instance = new T();
    public static T Instance => instance;
}
