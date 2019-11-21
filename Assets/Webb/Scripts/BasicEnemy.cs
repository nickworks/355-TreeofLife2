using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Webb
{
    public class BasicEnemy : MonoBehaviour
    {
        GameObject owner;
        Vector3 dirToPlayer;
        Vector3 offSet;
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
            offSet = new Vector3(0.0f, Random.Range(-2.0f, 3), 0.0f);
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null) attackTarget = player.transform;

        }

        // Update is called once per frame
        void Update()
        {
            if (age <= 5)
            {
                dirToPlayer = (attackTarget.position - transform.position + offSet);
            }
            else
            {
               Vector3 dirToPlayer = (attackTarget.position - transform.position  );
            }
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
            if (collider.transform.tag == "Player")
            {
                print("projectile hit something");
                Destroy(gameObject);
                HUDControler.playerHealth -= 25;
            }
        }
    }
}