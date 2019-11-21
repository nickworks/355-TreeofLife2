using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Wiles {
    public class WilesGUI : MonoBehaviour
    {
        public GameObject boss;
        WilesBossController bossController;

        public GameObject bossHealthBar;
        public List<GameObject> bossExtraBars = new List<GameObject>();

        public GameObject player;
        public GameObject playerHealthBar;

        public Text gameOverText;

        public GameObject level;
        WilesLevelScript levelScript;

        // Start is called before the first frame update
        void Start()
        {
            levelScript = level.GetComponent<WilesLevelScript>();
            bossController = boss.GetComponent<WilesBossController>();
            gameOverText.text = $" ";
        }

        // Update is called once per frame
        void Update()
        {
            bossHealthBar.transform.localScale = new Vector3(bossController.health / bossController.maxHealth, 1, 1);
            playerHealthBar.transform.localScale = new Vector3(levelScript.playerHealth / levelScript.playerMaxHealth, 1, 1);
            if (bossController.extraHealth > 2) bossController.extraHealth = 2;
            if (bossController.extraHealth == 1) bossExtraBars[1].transform.localScale = new Vector3(0, 0, 0);
            if (bossController.extraHealth == 0) bossExtraBars[0].transform.localScale = new Vector3(0, 0, 0);
            if (bossController.gameOver) gameOverText.text += $"GAME OVER! \n YOU WIN!";
            if (levelScript.gameOver) gameOverText.text += $"GAME OVER! \n YOU LOSE!";
        }
    }
}