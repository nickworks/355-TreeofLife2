using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Webb {
    public class BossStateIdel : BossState
    {
        // Start is called before the first frame update
        public override BossState Update(BossController boss)
        {


            Debug.Log("idle");
            //transstions

            if (boss.CanSeeAttackTarget())
            {
                return new BossStatePrsue();
            }
            return null;



        }

        

        public override void OnStart(BossController boss)
        {
           
        }
    }
    }
