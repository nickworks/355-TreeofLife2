using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Webb
{
    public class BossStateAttack : BossState
    {
        public static bool spawn;
        float timer;
        public BossController other;

        public override BossState Update(BossController boss)
        {
           // Vector3 vectorToPlayer = boss.VectorToAttackTarget();
           /* if (vectorToPlayer.sqrMagnitude > boss.pursueDistanceThreshold * boss.pursueDistanceThreshold)// if dis < htrshold 

            {                                                    // transtion to attack 
                return new BossStatePrsue();
            }*/
          
            Debug.Log("attack");
            
            spawn = true;
            timer += Time.deltaTime;
            if (spawn == true & timer >= 3)
            {
                spawn = false;
                return new BossStateCoolDown();

            }
            return null;

        }
    }
}
