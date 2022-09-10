using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public static GameOverController Instance { get; private set; }
    //
    [SerializeField] private GameObject _gameOverPanel;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {

    }

    public void SetGameOver()
    {
        Time.timeScale = 0;
        _gameOverPanel.SetActive(true);
    }
}
