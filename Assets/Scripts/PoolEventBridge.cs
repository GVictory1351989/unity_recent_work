using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PoolEventBridge : MonoBehaviour
{
    private void Awake()
    {
        EventManager.Subscribe<Component>(OnReturnToPoolRequested);
    }
    private void OnDestroy()
    {
        EventManager.Unsubscribe<Component>(OnReturnToPoolRequested);
    }

    private void OnReturnToPoolRequested(object sender, GameEvent<Component> evt)
    {
        if (evt.Data != null)
        {
            PoolManager.ReturnToPool(evt.Data);
        }
    }
}
