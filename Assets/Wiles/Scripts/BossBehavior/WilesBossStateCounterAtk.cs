using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wiles { 
public class WilesBossStateCounterAtk : WilesBossState
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        public override WilesBossState Update(WilesBossController boss)
        {
            // BOSS BEHAVIOR
            // Perform Atk Animation.
            // Once animation is complete, transition to Return2Center State.

            Debug.Log(this);

            // TRANSISTIONS:

            return null; // stay in current state
        }
    }
}