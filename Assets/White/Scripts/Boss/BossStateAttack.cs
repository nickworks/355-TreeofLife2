using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace White
{
    public class BossStateAttack : BossState
    {
        float timeBetweenShots = 0.5f;
        float timeUntilNextShot = 0;

        public override BossState Update(WhiteBossController boss)
        {
            Debug.Log("attack");
            /////////////////////// TRANSITIONS:
            // if the player starts to get too far away from the enemy
            // move the enemy toward the player

            timeUntilNextShot -= Time.deltaTime;
            if(timeUntilNextShot <=0)
            {
                boss.ShootProjectile();
                timeUntilNextShot = timeBetweenShots;
            }

            boss.ShootProjectile();

            if (!boss.CanSeeAttackTarget()) return new BossStateIdle(); // if the player gets too far away from the enemy return the enemy to idle
            return null;
        }
    }
}