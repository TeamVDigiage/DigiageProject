using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem instance;
    public TextMeshProUGUI scoreText;
    public float score;
    public float inc;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        inc = 10;
    }
    void Update()
    {
        //if (!RotateCol.instance.rotate)
        //{
        //    score += Time.deltaTime * inc;
        //    scoreText.text = "" + (int)score;
        //}
        score += Time.deltaTime * inc;
        scoreText.text = "" + (int)score;
    }
}
