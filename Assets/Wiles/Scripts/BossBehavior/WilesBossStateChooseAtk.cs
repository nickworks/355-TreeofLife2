using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wiles
{
    public class WilesBossStateChooseAtk : WilesBossState
    {

        private int chosenAtk;
        int numberOfAtks = 10;

        float timer = 0;

        // Start is called before the first frame update
        void Start()
        {
            Debug.Log(numberOfAtks);
            chosenAtk = Random.Range(0, numberOfAtks);
        }

        // Update is called once per frame
        public override WilesBossState Update(WilesBossController boss)
        {
            // BOSS BEHAVIOR
            // Using a random number, select an ATK.
            // Once a pattern has been decided, there should be a specific position for the boss to go to based on the chosen ATK.
            // Once the boss is in position, transition into that boss state.

            Debug.Log(this);
            Debug.Log(chosenAtk);

            timer += Time.deltaTime;

            // TRANSISTIONS:

            if (timer >= chosenAtk) return new WilesBossStateAttack();

            return null; // stay in current state
        }
    }
}