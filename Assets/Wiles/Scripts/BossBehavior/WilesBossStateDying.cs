using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wiles { 
public class WilesBossStateDying : WilesBossState
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        public override WilesBossState Update(WilesBossController boss)
        {
            // BOSS BEHAVIOR
            // Play the dying Animation.
            // Once the animation is done, Do game over, congratultations, you win, etc.

            Debug.Log(this);

            // TRANSISTIONS:

            return null; // stay in current state
        }
    }
}