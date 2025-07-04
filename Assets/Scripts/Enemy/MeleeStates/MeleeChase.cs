﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

[Preserve]
[FSMState("Chase")]
public class MeleeChase : IFSMState<MeleeEnemy>
{
    private float speed = 15f;
    private Transform Player;
    public void Enter(FSMAbstract<MeleeEnemy> fsmentity)
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    public void Update(FSMAbstract<MeleeEnemy> fsmentity)
    {
        Vector3 dir = (Player.position - fsmentity.transform.position).normalized;
        fsmentity.transform.position += dir * speed * Time.deltaTime;
        float dist = Vector3.Distance(Player.position, fsmentity.transform.position);
        if (dist <= 4f) 
        {
            fsmentity.ChangeStateByName("Attack");
        }
    }

    public void Exit(FSMAbstract<MeleeEnemy> fsmentity)
    {
    }
}

