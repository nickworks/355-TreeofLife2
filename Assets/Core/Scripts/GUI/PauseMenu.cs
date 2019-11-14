using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused { get; private set; }
    public EventSystem events;

    float prePauseTimeScale = 1;

    void Start() {
        isPaused = true;
        prePauseTimeScale = Time.timeScale;
        Time.timeScale = 0;
        if (events == null) events = GameObject.FindObjectOfType<EventSystem>();
    }
    void Update() {
        Focus();

        if (Input.GetButtonDown("Pause")) {
            BttnResume();
        }

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

    public void BttnResume() {
        Time.timeScale = prePauseTimeScale;
        isPaused = false;
        Destroy(gameObject);
    }
    public void BttnExit() {
        Time.timeScale = 1;
        isPaused = false;
        SceneManager.LoadScene("MainMenu");
    }
}
