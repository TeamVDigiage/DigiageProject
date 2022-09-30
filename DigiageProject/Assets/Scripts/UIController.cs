using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public GameObject _leaderBoardUI;
    public Button _newGameButton;
    public Button _exitGameButton;
    public Button _leaderBoardButton;
    public PlayfabManager playfab;

    public bool isOpened;
    void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("FinalScene"))
        {
            _exitGameButton.onClick.AddListener(ExitGame);
            _newGameButton.onClick.AddListener(EnterLevel);
            _leaderBoardButton.onClick.AddListener(OpenLeaderBoard);
        }

    }
    public void EnterLevel()
    {
        Debug.Log("Final Scene yukleniyor");
        SceneManager.LoadScene("FinalScene");
    }
    public void ExitGame()
    {
        Debug.Log("Oyun kapatiliyor");
        Application.Quit();
    }
    public void OpenLeaderBoard()
    {
        playfab.GetLeaderboard();
        isOpened = _leaderBoardUI.activeSelf;
        _leaderBoardUI.SetActive(!isOpened);
    }

}
