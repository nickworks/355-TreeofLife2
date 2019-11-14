using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wiles
{
    public class WilesBossStateChooseAtk : WilesBossState
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        public override WilesBossState Update(WilesBossController boss)
        {
            // BOSS BEHAVIOR
            // Using a random number, select an ATK.
            // Once a pattern has been decided, there should be a specific position for the boss to go to based on the chosen ATK.
            // Once the boss is in position, transition into that boss state.

            Debug.Log(this);

            // TRANSISTIONS:

            return null; // stay in current state
        }
    }
}