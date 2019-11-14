using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Johnson
{
    public class BossStateIdle : BossState
    {
        public override BossState Update(BossStateMachine boss)
        {
            //do stuff to the boss...

            Debug.Log("idle");

            // transitions to other states

            if (boss.CanSeeAttackTarget())
            {
                // transition to pursue state...
                return new BossStateShoot();
            }

            return null; // stay in current state
        }

        
        public override void OnStart(BossStateMachine boss)
        {
            


        }
    }
}