using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;

public class LeaderBoard : MonoBehaviour
{
    public static LeaderBoard Instance;
    public List<TextMeshProUGUI> leaderboard;
    PlayfabManager playfab;
    private void Awake()
    {
        Instance = this;
        playfab = gameObject.GetComponent<PlayfabManager>();
    }
    void Start()
    {
        //Invoke("Run", 3);
    }
    public void Run()
    {
        Debug.Log("adaads");
        playfab.GetLeaderboard();
    }
    private void Update()
    {
        Run();
    }
}
