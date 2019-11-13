using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wiles
{
    public class WilesBossStatePursue : WilesBossState
    {
        public override WilesBossState Update(WilesBossController boss)
        {

            ////////////////////////////////////// STATE BEHAVIOR:

            // move towards the player:

            Vector3 vectorToPlayer = boss.VectorToAttackTarget();

            Vector3 dirToPlayer = vectorToPlayer.normalized;
            //vectorToPlayer.Normalize();
            boss.transform.position += dirToPlayer * boss.speed * Time.deltaTime;



            ///////////////////////////////////////////////////////////////////////////////////////////// TRANSITIONS:

            if (vectorToPlayer.sqrMagnitude < boss.pursueDistanceThreshold * boss.pursueDistanceThreshold) {// If distance < threshold:
                return new WilesBossStateAttack();// transition to attack
            }



            if (!boss.CanSeeAttackTarget()) // if we can't see the player..
            {
                return new WilesBossStateIdle(); // transition to idle
            }


            Debug.Log(this);
            return null;
        }
    }
}