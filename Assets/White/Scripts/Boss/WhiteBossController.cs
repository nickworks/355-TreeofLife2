using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace White
{
    public class WhiteBossController : MonoBehaviour
    {
        public float visionDistanceThreshold = 10;
        public float pursueDistanceThreshold = 7;
        public float speed = 10;

        [HideInInspector]
        public Vector3 velocity = new Vector3();

        BossState currentState;

        public Transform attackTarget { get; private set; }

        void Start()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if(player != null) attackTarget = player.transform;

        }

        void Update()
        {
            if (currentState == null) SwitchToState(new BossStateIdle());

            if (currentState != null) SwitchToState(currentState.Update(this));
        }

        private void SwitchToState(BossState newState)
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
            if (attackTarget == null) return false;
            Vector3 vectorBetween = VectorToAttackTarget();

            if (vectorBetween.sqrMagnitude < visionDistanceThreshold * visionDistanceThreshold)
            {
                // player is close enough to boss to activate it
                Ray ray = new Ray(transform.position, vectorBetween.normalized);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.transform == attackTarget) return true;
                }
            }
            return false;
        }
    }
}