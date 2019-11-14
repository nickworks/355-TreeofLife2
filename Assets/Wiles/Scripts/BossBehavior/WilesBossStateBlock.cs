using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wiles { 
public class WilesBossStateBlock : WilesBossState
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        public override WilesBossState Update(WilesBossController boss)
        {
            // BOSS BEHAVIOR
            // While in this state, look for playerProjectiles being aimed at the boss (maybe using raycasts...???)
            // If there are playerProjectiles incoming, have blocking animation.
            // While in blocking animation, count a timer.
            // If that timer reaches a certain amount, transition into CounterAtk State
            // If no projectiles are found, wait a second, then animate back into idle before actualling transistioning into full idle state.

            Debug.Log(this);

            // TRANSISTIONS:

            return null; // stay in current state
        }
    }
}