using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wiles
{
    public class WilesBossController : MonoBehaviour
    {

        public float visionDistanceThreshold = 10;
        public float pursueDistanceThreshold = 7;
        public float speed = 10;

        public Projectile prefabProjectile;
        public ProjectileHoming prefabProjectileHoming;

        [HideInInspector]
        public Vector3 velocity = new Vector3();

        WilesBossState currentState;

        public Transform attackTarget { get; private set; }

        // Start is called before the first frame update
        void Start()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if(player !=null) attackTarget = player.transform;
        }

        // Update is called once per frame
        void Update()
        {

            if (currentState == null) SwitchToState( new WilesBossStateIdle());
            if (currentState != null) SwitchToState(currentState.Update(this));

        }

        private void SwitchToState(WilesBossState newState)
        {
            if (newState != null)
            {
                if(currentState != null) currentState.OnEnd(this);
                currentState = newState;
                currentState.OnStart(this);
            }
        }

        public Vector3 VectorToAttackTarget()
        {
            return attackTarget.position - transform.position;
        }

        public float DistanceToAttackTarget()
        {
            return VectorToAttackTarget().magnitude;

        }

        public bool CanSeeAttackTarget()
        {
            // if dis < threshold && raycast from player to boss hits...
            // transition to pursue
            if (attackTarget == null) return false;
            Vector3 vectorBetween = VectorToAttackTarget();

            if (vectorBetween.sqrMagnitude < visionDistanceThreshold * visionDistanceThreshold)
            {
                // player is close enough to boss to activate it...
                Ray ray = new Ray(transform.position, vectorBetween.normalized);
                // RaycastHit hit;
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    //Debug.Log("Raycast from boss to player hit something!!");
                    if (hit.transform == attackTarget) return true; // clear line of vision!
                }
            }
            return false;
        }


        public void ShootProjectile()
        {
            Projectile newProjectile = Instantiate(prefabProjectile, transform.position, Quaternion.identity);
            Vector3 dir = (VectorToAttackTarget()).normalized;
            newProjectile.Shoot(gameObject, dir);
        }

        public void ShootHomingProjectile()
        {
            ProjectileHoming newProjectile = Instantiate(prefabProjectileHoming, transform.position, Quaternion.identity);
            newProjectile.Shoot(gameObject, attackTarget, Vector3.up);
        }

    }
}