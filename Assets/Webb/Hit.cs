using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Webb
{
    public class Hit : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        void OnTriggerEnter(Collider collider)


        {
            if (collider.transform.tag == "Player")
            {
                // print("hit");
                print("projectile hit something");
                HUDControler.playerHealth -= 50;
                
            }


        }
    }
}
