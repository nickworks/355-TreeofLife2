using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPauseMenu : MonoBehaviour
{
    public PauseMenu prefabPauseMenuGUI;

    void Update()
    {
        if (PauseMenu.isPaused) return;
        if (Input.GetButtonDown("Pause")) Instantiate(prefabPauseMenuGUI);
    }
}
