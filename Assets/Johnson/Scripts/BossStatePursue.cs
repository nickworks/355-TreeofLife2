using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Johnson
{
    public class BossStatePursue : BossState
    {
        public override BossState Update(BossStateMachine boss)
        {

            ///////////////////////////// STATE BEHAVIOR: 
            Vector3 vectorToPlayer = boss.VectorToAttackTarget();

            Vector3 dirToPlayer = vectorToPlayer.normalized;

            boss.transform.position += dirToPlayer * boss.speed * Time.deltaTime;



            //////////////////////////// TRANSITION:
            ///
            if(vectorToPlayer.sqrMagnitude < boss.pursueDistanceThreshold * boss.pursueDistanceThreshold) // if dis < threshold
            {
                return new BossStatePursue();
            }

            if (!boss.CanSeeAttackTarget()) // if we can't see the player..
            {
                // transition to idle
                return new BossStateIdle();
            }

            return null;
        }
    }
}