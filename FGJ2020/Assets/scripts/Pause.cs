using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool paused = false;
    private string pauseButton = "PauseButton";
    public readonly string startScreenName = "StartingScreen";
    private GUIStyle guiStyle = new GUIStyle();
    private int fonttiKoko = 150;

    void Update()
    {
        if (Input.GetButtonDown(pauseButton))
            paused = TogglePause();
    }

    void Awake()
    {
        guiStyle.fontSize = fonttiKoko;
    }

    void OnGUI()
    {
        if (paused)
        {
            guiStyle.fontSize = fonttiKoko;
            int leveys = 140;
            int korkeus = 100;
            GUILayout.BeginArea(new Rect(Screen.width / 2f - leveys/2, Screen.height / 2f - korkeus/2, leveys, korkeus), guiStyle);
            GUILayout.Label("Game is paused!","box");
            GUILayout.Space(10f);
            if (GUILayout.Button("Unpause"))
                paused = TogglePause();
            if (GUILayout.Button("Main menu"))
            {
                TogglePause();
                UnityEngine.SceneManagement.SceneManager.LoadScene(startScreenName);
            }

            GUILayout.EndArea();
        }
    }

    bool TogglePause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            return (false);
        }
        else
        {
            Time.timeScale = 0f;
            return (true);
        }
    }
}
