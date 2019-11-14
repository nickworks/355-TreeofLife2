using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wiles
{
    public class WilesBossStateAttack : WilesBossState
    {
        public override WilesBossState Update(WilesBossController boss)
        {
            ////////////////////////////////////// STATE BEHAVIOR:

            // Do attack-ey stuff

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