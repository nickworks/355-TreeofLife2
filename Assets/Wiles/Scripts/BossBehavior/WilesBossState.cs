using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wiles
{
    public abstract class WilesBossState
    {
        // Update is called once per frame
        public abstract WilesBossState Update(WilesBossController boss);

        public virtual void OnStart(WilesBossController boss) { }
        public virtual void OnEnd(WilesBossController boss) { }

        // Start is called before the first frame update
        void Start()
        {

        }
    }
}