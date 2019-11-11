using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Webb
{
    public class BossStateAttack : BossState
    {
        public static bool spawn;
        int timer;
        public override BossState Update(BossController boss)
        {
            Vector3 vectorToPlayer = boss.VectorToAttackTarget();
            if (vectorToPlayer.sqrMagnitude > boss.pursueDistanceThreshold * boss.pursueDistanceThreshold)// if dis < htrshold 

            {                                                    // transtion to attack 
                return new BossStatePrsue();
            }
          
            Debug.Log("attack");
            spawn = true;
            timer += 1;
            if (spawn == true & timer >= 2)
            {
             
                return new BossStateIdel();
            }
            return null;

        }
    }
}
