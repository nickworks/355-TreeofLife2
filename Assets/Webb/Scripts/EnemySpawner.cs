using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Webb
{
    public class EnemySpawner : MonoBehaviour
    {
        // Start is called before the first frame update
        public GameObject enemeyBasic;
        Vector3 startPos;
       
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            startPos = gameObject.transform.position;
            if ( BossStateAttack.spawn == true)
            {
                print("spawn");
                Instantiate(enemeyBasic, startPos, Quaternion.identity);
            }
        }
    }
}