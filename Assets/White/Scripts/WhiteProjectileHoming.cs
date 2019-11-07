using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace White
{
    public class WhiteProjectileHoming : WhiteProjectile
    {
        Transform target;
        private float homingForce = 10000;
        float maxForce = 1000;

        public void Shoot(GameObject owner, Transform target, Vector3 direction)
        {
            this.target = target;

            Shoot(owner, direction);
        }

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
            steer = steer.normalized * maxForce;

            body.AddForce(steer * Time.deltaTime);
        }
    }
}