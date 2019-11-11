using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace webb
{
    public class Projectile : MonoBehaviour
    {
        GameObject owner;
        float lifeTime = 2;
        float age;
        public void Shoot(GameObject owner)
        {
            this.owner = owner;
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            age += Time.deltaTime;
            if (age >= lifeTime)
            {
                Destroy(gameObject);
            }
        }
        void OnTriggerEnter(Collider collider)
           

        {
            if (collider.gameObject == owner) return;
            print("projectile hit something");
            Destroy(gameObject);
            
        }
    }
}
