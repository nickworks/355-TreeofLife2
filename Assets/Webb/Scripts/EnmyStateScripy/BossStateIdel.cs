using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Webb {
    /// <summary>
    /// this class makes the game object do nothing except look for the player and swtitches to prusue
    /// </summary>
    public class BossStateIdel : BossState
    {
        // Start is called before the first frame update
        /// <summary>
        /// overides current update
        /// checks to see enemy this stwithces states
        /// </summary>
        /// <param name="boss"></param>
        /// <returns></returns>
        public override BossState Update(BossController boss)
        {


           // Debug.Log("idle");
            //transstions

            if (boss.CanSeeAttackTarget())
            {
                return new BossStatePrsue();
            }
            return null;



        }

        

       
    }
    }
