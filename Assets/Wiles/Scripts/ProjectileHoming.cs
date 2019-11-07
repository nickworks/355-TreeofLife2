using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wiles
{
    public class ProjectileHoming : Projectile
    {
        Transform target;
        private float homingForce = 10000;
        float maxforce = 1000;

        public void Shoot(GameObject owner,Transform target, Vector3 direction)
        {
            this.target = target;

            Shoot(owner, direction);
        }

        // Start is called before the first frame update
        void Start()
        {

        }



        // Update is called once per frame
        void Update()
        {
            GetOlderAndDie();
            Homing();

            transform.rotation = Quaternion.FromToRotation(Vector3.up, body.velocity.normalized);

        }

        private void Homing()
        {


            Vector3 dir = (target.position - transform.position).normalized;

            Vector3 steer = dir * homingForce - body.velocity;

            

            body.AddForce(dir * Time.deltaTime);
        }
    }
}