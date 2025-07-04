using UnityEngine;
public class EntityFactory
{
    public static T Create<T>(string type, int id) where T : FSMAbstract<T>
    {
        var go = new GameObject(typeof(T).Name);
        var fsm = go.AddComponent<T>();
        fsm.SetEntityID(type, id);
        return fsm;
    }
}