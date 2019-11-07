using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Webb
{
    public class BossStateAttack : BossState
    {
        public override BossState Update(BossController boss)
        {
            Vector3 vectorToPlayer = boss.VectorToAttackTarget();
            if (vectorToPlayer.sqrMagnitude > boss.pursueDistanceThreshold * boss.pursueDistanceThreshold)// if dis < htrshold 

            {                                                    // transtion to attack 
                return new BossStatePrsue();
            }
            Debug.Log("attack");
            return null;
        }
    }
}
