using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Johnson
{
    public class BossStateIdle : BossState
    {

        int pickAnAttack;
        bool isAttacking = false;
        int currentAttack = 0;

        public override BossState Update(BossStateMachine boss)
        {
            //do stuff to the boss...

            Debug.Log("idle");

            // transitions to other states

            if (boss.CanSeeAttackTarget())
            {
                // transition to pursue state...
                AttackList();
            }
            if (currentAttack == 1 && isAttacking == true)
            {
                
                Debug.Log("ATTACK01");
                return new BossStateShoot();
            }
            if (currentAttack == 2 && isAttacking == true)
            {

                Debug.Log("ATTACK02");
            }
            if (currentAttack == 3 && isAttacking == true)
            {

                Debug.Log("ATTACK03");
            }
            if (currentAttack == 4 && isAttacking == true)
            {

                Debug.Log("ATTACK04");
            }

            return null; // stay in current state
        }

        
        public override void OnStart(BossStateMachine boss)
        {
            
            ///pickAnAttack = Random.Range(1, 5);
            pickAnAttack = 1;

        }
        public override void OnEnd(BossStateMachine boss)
        {

            isAttacking = false;

        }

        public void AttackList()
        {
            if (pickAnAttack == 1)
            {
                currentAttack = 1;
                isAttacking = true;
                Debug.Log("01");
            }
            if (pickAnAttack == 2)
            {
                currentAttack = 2;
                isAttacking = true;
                Debug.Log("02");
            }
            if (pickAnAttack == 3)
            {
                currentAttack = 3;
                isAttacking = true;
                Debug.Log("03");
            }
            if (pickAnAttack == 4)
            {
                currentAttack = 4;
                isAttacking = true;
                Debug.Log("04");
            }
        }
    }
}