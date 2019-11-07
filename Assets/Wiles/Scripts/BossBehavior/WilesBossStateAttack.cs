using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wiles
{
    public class WilesBossStateAttack : WilesBossState
    {

        float timeBetweenShots = 0.5f;
        float timeUntilNextShot = 0;

        public override WilesBossState Update(WilesBossController boss)
        {
            ////////////////////////////////////// STATE BEHAVIOR:

            // Do attack-ey stuff

            timeUntilNextShot -= Time.deltaTime;

            if (timeUntilNextShot <0)
            {
                //boss.ShootProjectile();
                boss.ShootHomingProjectile();
                timeUntilNextShot = timeBetweenShots;
            }

            ///////////////////////////////////////////////////////////////////////////////////////////// TRANSITIONS:

            // If the attack target is too far away to attack, switch to pursue state.
            if (boss.VectorToAttackTarget().sqrMagnitude > boss.pursueDistanceThreshold * boss.pursueDistanceThreshold)
            {// If distance < threshold:
                return new WilesBossStatePursue();// transition to attack
            }

            Debug.Log(this);
            return null;
        }
    }
}