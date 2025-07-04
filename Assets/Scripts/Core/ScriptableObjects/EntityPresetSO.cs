using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSMAbstractComponent/PreSetSo")]
public class SComponent : ScriptableObject
{
    public string EnemyType; 
    public int EntityID;
    public Vector3 SpawnPoint;
    public Vector3 LastPosition;
    public bool MoveTowardsTarget; // basic move towards target
    public bool IsUpdate = true;
}
