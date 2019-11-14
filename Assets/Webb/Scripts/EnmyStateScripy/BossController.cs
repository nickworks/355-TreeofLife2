using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Webb
{
    public class BossController : MonoBehaviour
    {
        public float speed = 10;
        public float VisionDistanceThreshold = 40;
        public float pursueDistanceThreshold = 40;
        public float timer;
        Vector3 spawnPos;
        [HideInInspector]
        public Vector3 velocity = new Vector3();
        BossState currentState;
        public Projectile prefabProjectile;
     

        public Transform attackTarget { get; private set; }
        // Start is called before the first frame update
        void Start()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null) attackTarget = player.transform;

        }

        // Update is called once per frame
        void Update()
        {
            if (currentState == null) SwitchToState(new BossStateIdel());
            if (currentState != null) SwitchToState(currentState.Update(this));


        }

        private void SwitchToState(BossState newState)
        {
            if (newState != null)
            {
                if (currentState != null) currentState.OnEnd(this);

                currentState = newState;
                currentState.OnStart(this);
            }
        }
    
        public Vector3 VectorToAttackTarget()
        {
return  attackTarget.position - transform.position;
        }
public float distanceToAttackTarget()
        {
            return VectorToAttackTarget().magnitude;
        }
        public bool CanSeeAttackTarget()
        {
            if (attackTarget == null) return false;

            {
                Vector3 vectorBetween = VectorToAttackTarget();
                
                if (vectorBetween.sqrMagnitude < VisionDistanceThreshold * VisionDistanceThreshold)
                {
                    //player is close enogue to boss to activate it
                    Ray ray = new Ray(transform.position, vectorBetween.normalized);

                    if (Physics.Raycast(ray, out RaycastHit hit))
                    {

                        if (hit.transform == attackTarget) return true;
                        //clear line of vision


                        // if distances < thershold && raycast from player to boss hits..
                        // transtion to prsue

                    }
                }
            }
            return false;
        }
    public void Follow()
        {
            Vector3 vectorToPlayer = VectorToAttackTarget();
            Vector3 dirToPlayer = (attackTarget.position - transform.position).normalized;
            transform.position += dirToPlayer * speed * Time.deltaTime;
        }
        public void ShootProjectile()
        {
            timer += Time.deltaTime;
            if (timer >= .7) { 
            
            spawnPos = gameObject.transform.position;
            Instantiate(prefabProjectile, spawnPos, Quaternion.identity);
            timer = 0;
        }
        }
    }
}


