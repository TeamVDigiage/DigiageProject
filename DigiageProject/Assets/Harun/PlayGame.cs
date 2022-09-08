using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Leaderboard()
    {
        SceneManager.LoadScene(2);
    }
    public void GoMenu()
    {
        SceneManager.LoadScene(0);
    }
}
