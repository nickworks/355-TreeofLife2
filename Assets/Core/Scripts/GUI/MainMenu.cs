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
    void Update() {
        Focus();
    }

    /// <summary>
    /// This method focuses on the menu if no objects are in focus.
    /// </summary>
    private void Focus() {
        if (events == null) return;
        if (events.currentSelectedGameObject != null) return;
        if (events.firstSelectedGameObject == null) return;
        events.SetSelectedGameObject(events.firstSelectedGameObject);
    }

    public void BttnPlay(string levelname) {
        SceneManager.LoadScene(levelname);
    }

    public void BttnExit() {
        Application.Quit();
    }
}
