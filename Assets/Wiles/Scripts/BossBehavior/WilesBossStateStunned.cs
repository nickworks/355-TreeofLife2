using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wiles { 
public class WilesBossStateStunned : WilesBossState
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        public override WilesBossState Update(WilesBossController boss)
        {
            // BOSS BEHAVIOR
            // Play the intoStunned, Stunned, and ExitStunned animations.
            // Once the animations are done, transition to Return2Center state.
            // However, if the boss loses too much health, immedeately transition to DamageRecoil State.

            Debug.Log(this);

            // TRANSISTIONS:

            return null; // stay in current state
        }
    }
}