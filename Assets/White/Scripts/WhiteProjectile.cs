using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace White
{
    [RequireComponent(typeof(Rigidbody))]
    public class WhiteProjectile : MonoBehaviour
    {
        protected GameObject owner;
        protected Rigidbody body;

        float speed = 10;
        /// <summary>
        /// How many seconds a projectile should live.
        /// </summary>
        float lifetime = 2;
        /// <summary>
        /// How many seconds this projectile has been alive.
        /// </summary>
        float age = 0;

        void Start()
        {
            body = GetComponent<Rigidbody>();
        }

        public void Shoot(GameObject owner, Vector3 direction)
        {
            this.owner = owner;
            body = GetComponent<Rigidbody>();
            body.velocity = direction * speed;
        }

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
            if (collider.gameObject == owner) return; // don't hit the shoot of this projectile

            //WhiteProjectile p collider.GetComponent<WhiteProjectile>();
            //if(p != null && dontHitOtherProjectiles)

            print("projectile hit something");
            Destroy(gameObject);
        }
    }
}