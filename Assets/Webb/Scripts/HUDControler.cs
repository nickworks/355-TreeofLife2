using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Webb
{
    public class HUDControler : MonoBehaviour
    {
        // Start is called before the first frame update
        public Image playerHealthBar;
        public RawImage win;
        public RawImage gameOver;
       static public float playerHealth = 550;
        float PlayerHealthMax = 550;
        public Image enemyHealthBar;
        static public float enemyHealth = 1000;
        float enemyHealthMax = 1000;


        void Start()
        {
            win.enabled = false;
            gameOver.enabled = false;


        }

        // Update is called once per frame
        void Update()
        {
            HUD();
            if (playerHealth <= 0 & win.enabled == false )
            {
                gameOver.enabled = true;
            }
            if (enemyHealth <= 0 & gameOver.enabled == false)
            {
                win.enabled = true;
            }
        }

        private void HUD()
        {
            

           
            playerHealthBar.fillAmount = playerHealth / PlayerHealthMax;
            enemyHealthBar.fillAmount = enemyHealth / enemyHealthMax;
        }

  
    }
}