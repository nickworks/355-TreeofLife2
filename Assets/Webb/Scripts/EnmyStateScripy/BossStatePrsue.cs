using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Webb
{
    public class BossStatePrsue : BossState
    {
        // Start is called before the first frame update
        public override BossState Update(BossController boss)
        {//////////// State Behavior
         // move towards player
           Vector3 vectorToPlayer = boss.VectorToAttackTarget();
           /* Vector3 dirToPlayer = (boss.attackTarget.position - boss.transform.position).normalized;
            boss.transform.position += dirToPlayer * boss.speed * Time.deltaTime;
          */  boss.Follow();
            /////////////////////// transtions:
            if (EnemyHit.hit == true)
            {
                return new BossStateDamged();
            }
            if (vectorToPlayer.sqrMagnitude < boss.pursueDistanceThreshold * boss.pursueDistanceThreshold)// if dis < htrshold 
           
            {                                                    // transtion to attack 
                return new BossStateAttack();
            }

                if (!boss.CanSeeAttackTarget())  /// if we cant see player...
            return new BossStateIdel();/// transtion to idle
            return null;
        }
    }
}
