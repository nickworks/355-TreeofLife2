using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Webb { 

    public class BossStateCoolDown : BossState
    {
        float timer;
        // Start is called before the first frame update
        public override BossState Update(BossController boss)
        {
            Debug.Log("cooling off");
            timer += Time.deltaTime;
            if(timer >= 5)
            {
                return new BossStateIdel();
            }
            return null;
        }
    }
}
