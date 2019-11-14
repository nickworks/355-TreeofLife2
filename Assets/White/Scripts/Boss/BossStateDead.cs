using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace White
{
    public class BossStateDead : BossState
    {
        public override BossState Update(WhiteBossController boss)
        {
            // destroy the boss
            return null;
        }
    }
}