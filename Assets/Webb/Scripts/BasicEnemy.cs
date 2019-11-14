using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Webb
{
    public class BasicEnemy : MonoBehaviour
    {
        GameObject owner;


        float lifeTime = 15;
        int speed = 5;
        float age;
        public void Shoot(GameObject owner)
        {
            this.owner = owner;
        }
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
            Vector3 dirToPlayer = (attackTarget.position - transform.position);
            transform.position += dirToPlayer.normalized * speed * Time.deltaTime;

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