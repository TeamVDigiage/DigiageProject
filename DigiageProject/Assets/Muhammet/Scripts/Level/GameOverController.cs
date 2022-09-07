using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void SetGameOver()
    {
        Debug.Log("Game Over Method");
        _gameOverPanel.SetActive(true);
    }
}
