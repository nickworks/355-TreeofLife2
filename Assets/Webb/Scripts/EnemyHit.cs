using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Webb
{
    public class EnemyHit : MonoBehaviour
    {
        // Start is called before the first frame update
        public static bool hit;
        void OnTriggerEnter(Collider collider)


        {
            if (collider.transform.tag == "Player")
            {
                // print("hit");
                print("projectile hit something");
                HUDControler.enemyHealth -= 100;
                hit = true;
            }
        }
            void OnTriggerExit(Collider collider)


            {
                if (collider.transform.tag == "Player")
                {
                // print("hit");
                print("player gone");

                hit = false;
                }


            

        }
    }
}