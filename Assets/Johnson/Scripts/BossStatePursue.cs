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

            
            if (!boss.CanSeeAttackTarget()) // if we can't see the player..
            {
                // transition to idle
                return new BossStateIdle();
            }
            else if (boss.DistanceToAttackTargt() < boss.attackDistanceThreshold)
            {
                return new BossStateAttack();
            }
            else if (boss.DistanceToAttackTargt() < boss.pursueDistanceThreshold)
            {
                return new BossStateShoot();
            }
            else
            {
                return null;
            }

            

            
        }
    }
}