using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    public EventSystem events;

    void Start() {
        if (events == null) events = GameObject.FindObjectOfType<EventSystem>();
    }

    // Update is called once per frame
    void Update() {
        
    }
    public void BttnPlay(string levelname) {
        SceneManager.LoadScene(levelname);
    }

    public void BttnExit() {
        Application.Quit();
    }
}
