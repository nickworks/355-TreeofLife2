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

            boss.transform.position = Vector3.MoveTowards(boss.transform.position, new Vector3(-60, 40, 100), boss.speed);

            Debug.Log(this);

            // TRANSISTIONS:

            if (boss.transform.position == new Vector3(-60, 40, 100)) return new WilesBossStateIdle();

            return null; // stay in current state
        }
    }
}