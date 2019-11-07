using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Johnson
{
    public abstract class BossState
    {

        public abstract BossState Update(BossStateMachine boss);

        public virtual void OnStart(BossStateMachine boss) { }
        public virtual void OnEnd(BossStateMachine boss) { }

    }
}