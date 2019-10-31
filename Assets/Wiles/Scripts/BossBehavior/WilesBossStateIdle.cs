using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wiles
{
    public class WilesBossStateIdle : WilesBossState
    {
        public override WilesBossState Update(WilesBossController boss)
        {
            // do stuff to the boss...

            Debug.Log(this);

            // transitions to other states:


            if (boss.CanSeeAttackTarget())
            {
                // transition to pursure state...
                return new WilesBossStatePursue();
            }

            return null; // stay in current state
        }

       

        public override void OnStart(WilesBossController boss)
        {
            // base.OnStart(boss);



        }

    }
}