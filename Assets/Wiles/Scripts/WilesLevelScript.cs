﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wiles
{
    public class WilesLevelScript : MonoBehaviour
    {

        public GameObject player;
        public Projectile playerProjectile;
        public float playerHealth = 100;
        public float playerMaxHealth = 100;

        Transform attackTarget;
        Ray ray;

        public bool gameOver = false;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            
            if (Input.GetMouseButtonDown(0))
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                ShootProjectile();
            }
        }
        void ShootProjectile()
        {
            Projectile newProjectile = Instantiate(playerProjectile, player.transform.position, Quaternion.identity);
            Vector3 dir = (VectorToAttackTarget()).normalized;
            newProjectile.Shoot(player, dir);

        }
        Vector3 VectorToAttackTarget()
        {
            return ray.direction;
        }
        public void PlayerCollision()
        {
            if (gameOver) return;
            playerHealth -= 10.0f;
            if (playerHealth <= 1) gameOver = true;
        }
    }
}