using System;
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

            return null; // stay in current state
        }

        public override void OnStart(WhiteBossController boss)
        {
            
        }
    }
}