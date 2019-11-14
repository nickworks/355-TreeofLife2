using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Webb
{
    public class EnemySpawner : MonoBehaviour
    {
        // Start is called before the first frame update
        public GameObject enemeyBasic;
        Vector3 spawnPos;
        float timer;
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
          
        {
            timer += Time.deltaTime;
            spawnPos = gameObject.transform.position;
            if ( BossStateAttack.spawn == true & timer >= .7)
            {
                print("spawn");
              
                Instantiate(enemeyBasic, spawnPos, Quaternion.identity);
                timer = 0;
            }
        }
    }
}