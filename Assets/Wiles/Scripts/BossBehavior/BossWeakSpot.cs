using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wiles {
    public class BossWeakSpot : MonoBehaviour
    {

        public GameObject boss;
        WilesBossController bossController;

        // Start is called before the first frame update
        void Start()
        {
            bossController = boss.GetComponent<WilesBossController>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void TakeDamage(int dmg)
        {
            bossController.takeDamage(dmg);
        }
    }
}