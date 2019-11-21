﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wiles
{
    [RequireComponent(typeof(Rigidbody))]
    public class Projectile : MonoBehaviour
    {

        protected GameObject owner;
        protected List<GameObject> ownersChildren = new List<GameObject>();
        protected Rigidbody body;

        //public GameObject levelScript;

        float speed = 100;
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
            //this.ownersChildren = owner.transform.get
            for (int i = 0; i < owner.transform.childCount; i++)
            {
                GameObject child = this.owner.transform.GetChild(i).gameObject;
                //Do something with child
                ownersChildren.Add(child);

            }
            body = GetComponent<Rigidbody>();
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
            for (int i = 0; i < ownersChildren.Count; i++) // Don't hit any of the shooter's children
            {
                //Do something with child
                if (collider.gameObject == ownersChildren[i]) return;
            }

            Projectile p = collider.GetComponent<Projectile>(); // Checks if this collided w/ a projectile

            if (p != null && p.owner == owner) return; // Don't collide w/ projectiles from the same owner.

            if(collider.GetComponent<PlayerController2>() != null) // We've collided w/ the player
            {// Here I'd like to add another check to make sure the projectile after hitting the player wasn't shot by the player.
                //^This^ should have already been done earlier, but it doesn't hurt to double check.
                WilesLevelScript level;
                if((level = GetComponentInParent<WilesLevelScript>()) != null)
                {
                    level.PlayerCollision();

                    print("projectile hit " + collider.gameObject + "'s " + collider);

                    Destroy(gameObject);
                }
            }


            print("projectile hit " + collider.gameObject + "'s " +  collider);

            collider.gameObject.BroadcastMessage("TakeDamage", 1); // Send a message to this object, if it has this function, run it!

            Destroy(gameObject);
        }

    }
}