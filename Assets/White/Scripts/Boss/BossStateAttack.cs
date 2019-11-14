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

            Vector3 vectorToPlayer = boss.VectorToAttackTarget();

            Vector3 dirToPlayer = vectorToPlayer.normalized;
            boss.transform.position += dirToPlayer * boss.speed * Time.deltaTime * 2;

            /*timeUntilNextShot -= Time.deltaTime;
            if(timeUntilNextShot <=0)
            {
                boss.ShootProjectile();
                timeUntilNextShot = timeBetweenShots;
            }

            boss.ShootProjectile();*/

            //if (!boss.CanSeeAttackTarget()) return new BossStateIdle(); // if the player gets too far away from the enemy return the enemy to idle

            // switch to retreat state
            // once the boss has finished its attack, it retreats a short distance away from the player

            // switch to dead state

            return null;
        }
    }
}