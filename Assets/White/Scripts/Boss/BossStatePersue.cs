using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace White
{
    public class BossStatePersue : BossState
    {
        public override BossState Update(BossController boss)
        {
            // move towards player:
            Vector3 vectorToPlayer = boss.VectorToAttackTarget();
            
            Vector3 dirToPlayer = vectorToPlayer.normalized;
            boss.transform.position += dirToPlayer * boss.speed * Time.deltaTime;

            /////////////////////////// TRANSITIONS:

            if(vectorToPlayer.sqrMagnitude < boss.pursueDistanceThreshold * boss.pursueDistanceThreshold) return new BossStateAttack(); // if dis < threshold transition to attack

            if (!boss.CanSeeAttackTarget()) return new BossStateIdle(); // if we can't see the player transition to idle

            return null;
        }
    }
}