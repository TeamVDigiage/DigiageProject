using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseGameMenu : MonoBehaviour
{
    public static bool isGamePaused;

    public GameObject gameplayUI;
    public GameObject pauseMenuUI;
    public GameObject _infoMenuUI;
    public Button _pauseButton;
    public Button _resumeGameButton;
    public Button _newGameButton;
    public Button _mainMenuButton;
    public Button _infoButton;
    public Button _resumeButton;

    void Start()
    {
        isGamePaused = false;
        _pauseButton.onClick.AddListener(PauseGame);
        _resumeGameButton.onClick.AddListener(ResumeGame);
        _newGameButton.onClick.AddListener(RestartGame);
        _infoButton.onClick.AddListener(OpenInfoMenu);
    }
    private void Update()
    {
        Debug.Log(Time.deltaTime);
    }

    public void ResumeGame()
    {
        Debug.Log("Oyun resume edildi");
        gameplayUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        _infoMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }
    public void PauseGame()
    {
        Debug.Log("Oyun durdu");
        gameplayUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OpenInfoMenu()
    {
        gameplayUI.SetActive(false);
        _infoMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void CloseInfo()
    {
        _infoMenuUI.SetActive(false);
        gameplayUI.SetActive(true);
        Time.timeScale = 1f;
    }


}
