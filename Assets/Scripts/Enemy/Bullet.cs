using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float lifetime = 3f;
    public int damage = 10;
    void Start()
    {
        Destroy(gameObject, lifetime);
    }
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        EventManager.Publish(null, new GameEvent<HitEvent>(new HitEvent { HittedObject = other.gameObject }, null)) ;
        Destroy(gameObject);
        
    }
}
