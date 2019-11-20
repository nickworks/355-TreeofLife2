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
       static public float playerHealth = 550;
        float PlayerHealthMax = 550;
        public Image enemyHealthBar;
        static public float enemyHealth = 1000;
        float enemyHealthMax = 1000;


        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            HUD();
            
        }

        private void HUD()
        {
            

           
            playerHealthBar.fillAmount = playerHealth / PlayerHealthMax;
            enemyHealthBar.fillAmount = enemyHealth / enemyHealthMax;
        }

  
    }
}