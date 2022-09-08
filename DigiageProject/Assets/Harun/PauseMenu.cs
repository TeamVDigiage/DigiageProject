using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject panel;
    bool panelState;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panelState = panel.activeSelf;
            panel.SetActive(!panelState);
        }
        Application.quitting += Save;
    }
    public void GoMenu()
    {
        PlayfabManager.Instance.SendLeaderboard((int)ScoreSystem.instance.score);
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        Application.Quit();
    }
    void Save()
    {
        PlayfabManager.Instance.SendLeaderboard((int)ScoreSystem.instance.score);
    }
}
