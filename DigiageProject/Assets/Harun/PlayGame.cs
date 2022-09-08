using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayGame : MonoBehaviour
{
    public static PlayGame instance;
    public TextMeshProUGUI usersName;
    public PlayfabManager playfab;
    private void Awake()
    {
        instance = this;
    }
    public void Play()
    {
        playfab.SubmitNameButton();
        PlayerPrefs.SetString("Users", usersName.text);
        SceneManager.LoadScene(1);
    }
    public void Leaderboard()
    {
        playfab.GetLeaderboard();
        PlayerPrefs.SetString("Users", usersName.text);
        SceneManager.LoadScene(2);
    }
    public void GoMenu()
    {
        SceneManager.LoadScene(0);
    }
}
