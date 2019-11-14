using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wiles
{
    public class WilesBossStateIdle : WilesBossState
    {

        float timer = 0;

        public override WilesBossState Update(WilesBossController boss)
        {
            // BOSS BEHAVIOR
            // Wait for there to be any PlayerProjectile Objects in the scene.
            // If projectiles are found, determine if they are a threat. (A raycast from the projectiles hitting the boss's head)
            // After a number of seconds (12sec @ 100% Health, 1sec @ 1/12th Health), go into the ChooseAtk State.

            Debug.Log(this);

            timer += Time.deltaTime;

            // TRANSISTIONS:


            if (timer >= 12)
            {
                // transition to pursure state...
                return new WilesBossStateChooseAtk();
            }

            return null; // stay in current state
        }

       

        public override void OnStart(WilesBossController boss)
        {
            // base.OnStart(boss);



        }

    }
}