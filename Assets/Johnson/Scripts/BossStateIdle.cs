using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Johnson
{
    public class BossStateIdle : BossState
    {

        
        int shootOrPursueDecider;
        

        public override BossState Update(BossStateMachine boss)
        {

            //do stuff to the boss...

            Debug.Log("idle");

            // transitions to other states


            
            if (boss.DistanceToAttackTargt() < boss.visionDistanceThreshold)
            {
                
                return new BossStatePursue();
                                             
            }
            


            return null; // stay in current state
            
            
        }
        
        
    }
}