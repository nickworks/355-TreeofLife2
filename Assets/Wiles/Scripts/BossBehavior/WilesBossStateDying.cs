using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wiles { 
public class WilesBossStateDying : WilesBossState
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
            // Play the dying Animation.
            // Once the animation is done, Do game over, congratultations, you win, etc.

            Debug.Log(this);

            timer += Time.deltaTime;

            // TRANSISTIONS:

            if (timer >= 12) return new WilesBossStateReturn(); // This is where we get a game over, but for now we will have it on a closed loop.

            return null; // stay in current state
        }
    }
}