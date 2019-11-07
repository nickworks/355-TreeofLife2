using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace White
{
    public class BossStateAttack : BossState
    {
        public override BossState Update(WhiteBossController boss)
        {
            Debug.Log("attack");
            /////////////////////// TRANSITIONS:
            // if the player starts to get too far away from the enemy
            // move the enemy toward the player

            if (!boss.CanSeeAttackTarget()) return new BossStateIdle(); // if the player gets too far away from the enemy return the enemy to idle
            return null;
        }
    }
}