using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IEnemy
{
    Vector3 TargetPoint { get; set; }
    int Health { get; set; }
    float FireRate { get; set; }
    float StayTime { get; set; }
    EnemyType EnemyType { get; }
    void SetEntityConfigSO(float range,
                                 float cooldown,
                                 float damage,
                                 float staytime,
                                 int health,
                                 float speed,
                                 float rotateSpeed);
}
