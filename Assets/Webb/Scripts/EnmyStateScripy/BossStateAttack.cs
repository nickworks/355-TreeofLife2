//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Webb
{

    public class BossStateAttack : BossState
    {
        public static bool spawn;
        float timer;
        float time = 10;
        public BossController other;
        bool random;
        int attack;
        public override BossState Update(BossController boss)
        {
          if (random == false)
            {
                attack = Random.Range(2,3 );
                random = true;
            } 
          //  Debug.Log(attack);
            if (attack == 1)
            {
                boss.SpawnBasicEnemy();
                time = 5;
            }
            if (attack == 2)
            {
                boss.SpawnChargeEnmey();
                time = 2;
            }
            if (attack == 3)
            {
                boss.Charge();
                time = 1f;
            }
            //spawn = true;
            timer += Time.deltaTime;
            if (  timer >= time)
            {
                random = false;
                return new BossStateCoolDown();

            }
            if (EnemyHit.hit == true)
            {
                return new BossStateDamged();
            }
            return null;

        }
    }
}
