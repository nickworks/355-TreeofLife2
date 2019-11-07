using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace White
{
    public abstract class BossState
    {
        public abstract BossState Update(WhiteBossController boss);

        public virtual void OnStart(WhiteBossController boss) { }
        public virtual void OnEnd(WhiteBossController boss) { }
    }
}