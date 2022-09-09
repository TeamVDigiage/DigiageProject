using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Button _newGameButton;
    public Button _exitGameButton;
    void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("FinalScene"))
        {
            _exitGameButton.onClick.AddListener(ExitGame);
            _newGameButton.onClick.AddListener(EnterLevel);
        }

    }
    void EnterLevel()
    {
        Debug.Log("Final Scene yukleniyor");
        SceneManager.LoadScene("FinalScene");
    }
    void ExitGame()
    {
        Debug.Log("Oyun kapatiliyor");
        Application.Quit();
    }

}
