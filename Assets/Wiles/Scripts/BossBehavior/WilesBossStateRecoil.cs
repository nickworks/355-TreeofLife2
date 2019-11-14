using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wiles { 
public class WilesBossStateRecoil : WilesBossState
    {

        float timer = 0;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        public override WilesBossState Update(WilesBossController boss)
        {
            // BOSS BEHAVIOR
            // Play the HeavyDamageRecoil animation.
            // Once animation is done, transition to Return2Center state.

            Debug.Log(this);

            timer += Time.deltaTime;

            // TRANSISTIONS:

            if (timer >= 10) return new WilesBossStateReturn();

            return null; // stay in current state
        }
    }
}