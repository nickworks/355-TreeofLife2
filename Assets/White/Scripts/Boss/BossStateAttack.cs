using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace White
{
    public class BossStateAttack : BossState
    {
        public override BossState Update(BossController boss)
        {
            Debug.Log("Attack");
            return null;
        }
    }
}