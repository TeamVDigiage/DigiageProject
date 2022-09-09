using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class PlayfabManager : MonoBehaviour
{
    public static PlayfabManager Instance;
    public int index = 0;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Login();
    }

    // Update is called once per frame
    void Update()
    {
        //Login();
    }
    //public void Login()
    //{
    //    var request = new LoginWithCustomIDRequest
    //    {
    //        CustomId = "Tutorial",
    //        CreateAccount = true,
    //        InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
    //        {
    //            GetPlayerProfile = true
    //        }
    //    };
    //    PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnError);
    //}
    //void OnLoginSuccess(LoginResult result)
    //{
    //    string name = null;
    //    if (result.InfoResultPayload.PlayerProfile != null)
    //        name = result.InfoResultPayload.PlayerProfile.DisplayName;
    //}
    void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }
    void OnSuccess(LoginResult result)
    {
        Debug.Log("Successful");
    }
    void OnError(PlayFabError error)
    {
        Debug.Log("Error");
        Debug.Log(error.GenerateErrorReport());
    }
    public void SendLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName="RunnerScore",
                    Value=score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }
    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Successfull leaderboard");
    }
    public void GetLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "RunnerScore",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeadearboardGet, OnError);
    }
    void OnLeadearboardGet(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            Debug.Log(item.Position + "" + item.DisplayName + "" + item.StatValue);
            //LeaderBoard.Instance.leaderboardName[index].text = "        " + (item.Position + 1);
            LeaderBoard.Instance.leaderboard[index].text = "        " + item.StatValue;
            index++;
        }
        index = 0;
    }
    //public void SubmitNameButton()
    //{
    //    var request = new UpdateUserTitleDisplayNameRequest
    //    {
    //        DisplayName = PlayGame.instance.usersName.text
    //    };
    //    PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdate, OnError);
    //}
    //void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult result)
    //{
    //    Debug.Log("Successful Name Save");
    //}
}
