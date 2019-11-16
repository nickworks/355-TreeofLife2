using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Johnson
{
    public class BossStateAttack : BossState
    {

        int pickAnAttack;
        bool isAttacking = false;
        int currentAttack = 0;

        public override void OnStart(BossStateMachine boss)
        {

            pickAnAttack = Random.Range(1, 5);
            AttackList();
            ///pickAnAttack = 1;

        }

        public override BossState Update(BossStateMachine boss)
        {
            

            if (currentAttack == 1 && isAttacking == true)
            {

                Debug.Log("ATTACK01");
                
            }
            if (currentAttack == 2 && isAttacking == true)
            {

                Debug.Log("ATTACK02");
            }
            

            return null;
        }

        public override void OnEnd(BossStateMachine boss)
        {
            pickAnAttack = 0;
            currentAttack = 0;
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