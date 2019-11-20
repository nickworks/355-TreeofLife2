using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace webb
{
    public class HUDControler : MonoBehaviour
    {
        // Start is called before the first frame update
        public Image progressBar;
        float xp = 50;
        float xpMax = 350;
      
    
       
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
            

           
            progressBar.fillAmount = xp / xpMax;
            
        }

        public void ClearXpValue()
        {
            xp = 0;
        }
    }
}