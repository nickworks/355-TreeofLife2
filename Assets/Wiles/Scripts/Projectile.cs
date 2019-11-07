using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wiles
{
    [RequireComponent(typeof(Rigidbody))]
    public class Projectile : MonoBehaviour
    {

        protected GameObject owner;
        protected Rigidbody body;

        float speed = 10;
        /// <summary>
        ///  How many seconds this projectile should have
        /// </summary>
        float lifetime = 2;
        /// <summary>
        /// How many seconds this projectile has been alive.
        /// </summary>
        float age = 0;

        public void Shoot(GameObject owner, Vector3 direction)
        {
            this.owner = owner;
            body.velocity = direction * speed;
        }
        // Start is called before the first frame update
        void Start()
        {
            body = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            GetOlderAndDie();
        }

        protected void GetOlderAndDie()
        {
            age += Time.deltaTime;

            if (age >= lifetime) Destroy(gameObject);
        }

        void OnTriggerEnter(Collider collider)
        {

            if (collider.gameObject == owner) return; // don't hit the shooter of this projectile! (Will only work if the owner has 1 collider)

            Projectile p = collider.GetComponent<Projectile>();

            //if(p != null && [Don't hit other projectiles])

            //collider.GetComponent<PlayerController2>();

            collider.gameObject.BroadcastMessage("TakeDamage", 15); // Send a message to this object, if it has this function, run it!


            print("projectile hit something!");
            Destroy(gameObject);
        }

    }
}