using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wiles { 
public class WilesBossStateReturn : WilesBossState
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        public override WilesBossState Update(WilesBossController boss)
        {
            // BOSS BEHAVIOR
            // Return to the center of the Arena.
            // Once in position, transition into Idle.

            Debug.Log(this);

            // TRANSISTIONS:

            return null; // stay in current state
        }
    }
}