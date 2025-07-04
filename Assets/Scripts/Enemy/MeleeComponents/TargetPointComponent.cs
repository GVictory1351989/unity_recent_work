using UnityEngine;
using System;

[Serializable]
public struct TargetPointComponent
{
    public Vector3 Position;
    public float MoveSpeed;
    public TargetPointComponent(Vector3 pos,float moveSpeed)
    {
        Position = pos;
        MoveSpeed = moveSpeed;
    }
}
