using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Johnson
{
    public class BossStateShoot : BossState
    {
        public override BossState Update(BossStateMachine boss)
        {
            Debug.Log("Attack");
            return null;
        }
    }
}