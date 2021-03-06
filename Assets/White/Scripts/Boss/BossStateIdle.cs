﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace White
{
    public class BossStateIdle : BossState
    {
        public override BossState Update(WhiteBossController boss)
        {
            // do stuff to the boss...
            Debug.Log("idle");

            // transitions to other states:
            if (boss.CanSeeAttackTarget())
            {
                // transition to persue state...
                return new BossStatePersue();
            }

            // switch to move around level state

            // switch to dead state

            return null; // stay in current state
        }

        public override void OnStart(WhiteBossController boss)
        {
            
        }

        void OnTriggerEnter(Collider collider)
        {
            // if the boss was hit, return BossStateMove
            Debug.Log("boss was hit");

            return;
        }
    }
}