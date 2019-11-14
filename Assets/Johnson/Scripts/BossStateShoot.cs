using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Johnson
{
    public class BossStateShoot : BossState
    {

        float timeBetweenShots = .5f;
        float timeUntilNextShot = 2;

        public override BossState Update(BossStateMachine boss)
        {
            Debug.Log("Pew Pew");

            timeUntilNextShot -= Time.deltaTime;

            if(timeUntilNextShot <= 0)
            {
                boss.ShootHomingProjectile();
                timeUntilNextShot = timeBetweenShots;
            }

            //boss.ShootProjectile();

            return null;
        }

        
    }
}