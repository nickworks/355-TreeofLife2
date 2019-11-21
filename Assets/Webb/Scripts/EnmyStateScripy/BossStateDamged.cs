using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Webb
{
    public class BossStateDamged : BossState
    {
        float timer;
        float time = 1;
        public override BossState Update(BossController boss)
        {   boss.Retreat();
            timer += Time.deltaTime;
            if (timer >= time)
            {
             return new BossStateIdel();    
             
            }

            return null;
        }
    }
}