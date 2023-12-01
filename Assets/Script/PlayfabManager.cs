using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;
public class OnlinePlayerInfo
{
    public string PlayfabId;
    public string Name;
    public int Position;
    public int Value;

    public OnlinePlayerInfo(string playfabId, string name, int pos, int n)
    {
        PlayfabId = playfabId;
        Name = name;
        Position = pos;
        Value = n;
    }
}

public class PlayfabManager : MonoBehaviour
{
    private static PlayfabManager instance;
    public static PlayfabManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlayfabManager>();
            }
            return instance;
        }
    }

    string loggedInPlayfabId;

    void Start()
    {
        //Login("aaa");
    }
    public void Login(TMP_InputField input)
    {
        string displayName = input.text;
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, result => { OnSuccess(result, displayName); }, OnError);
    }
    void OnSuccess(LoginResult result, string displayName)
    {
        loggedInPlayfabId = result.PlayFabId;
        PlayFabClientAPI.UpdateUserTitleDisplayName(new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = displayName
        }, result =>
        {
            print("Successful log in with name: " + displayName);
        }, OnError);
        EventCenter.Broadcast(FunctionType.LoginSuccessful);
    }
    void OnError(PlayFabError result)
    {
        throw new UnityException(result.ErrorMessage);
    }
    public void SendLeaderboard(int time, string leaderboardName)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = leaderboardName,
                    Value = time
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }
    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        print("Successfull leaderboard sent!");
    }
    public void SendRecord(string key, string sr)
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                {key, sr}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);
    }
    void OnDataSend(UpdateUserDataResult result)
    {
        print("Successfull record sent!");
    }
    public void GetLeaderBoardPlayerPos(string key)
    {
        var request = new GetLeaderboardAroundPlayerRequest
        {
            StatisticName = key,
            MaxResultsCount = 1
        };
        PlayFabClientAPI.GetLeaderboardAroundPlayer(request, OnleaderboardPlayerPosGet, OnError);
    }
    void OnleaderboardPlayerPosGet(GetLeaderboardAroundPlayerResult result)
    {
        int pos = 0;
        foreach (var item in result.Leaderboard)
        {
            if (item.PlayFabId == loggedInPlayfabId)
            {
                pos = item.Position;
            }
        }
        OnlinePlayerInfo info = new OnlinePlayerInfo(result.Leaderboard[pos].PlayFabId, result.Leaderboard[pos].DisplayName, result.Leaderboard[pos].Position + 1, result.Leaderboard[pos].StatValue);
        EventCenter.Broadcast(FunctionType.UpdatePlayerInfo, info);
    }
    public void GetLeaderboardAround(string key)
    {
        var request = new GetLeaderboardAroundPlayerRequest
        {
            StatisticName = key,
            MaxResultsCount = 2
        };
        PlayFabClientAPI.GetLeaderboardAroundPlayer(request, OnLeaderboardAroundPlayerGet, OnError);
    }
    void OnLeaderboardAroundPlayerGet(GetLeaderboardAroundPlayerResult result)
    {
        int pos = 0;
        foreach (var item in result.Leaderboard)
        {
            if (item.PlayFabId == loggedInPlayfabId)
            {
                pos = item.Position - 1;
            }
        }
        if (pos < 0) pos = 0;
        OnlinePlayerInfo info = new OnlinePlayerInfo(result.Leaderboard[pos].PlayFabId, result.Leaderboard[pos].DisplayName, result.Leaderboard[pos].Position + 1, result.Leaderboard[pos].StatValue);
        EventCenter.Broadcast(FunctionType.UpdateRivalInfo, info);
    }
    public void GetUserData(string key, string id)
    {
        List<string> keys = new List<string>();
        keys.Add(key);

        var request = new GetUserDataRequest()
        {
            PlayFabId = id,
            Keys = keys
        };
        PlayFabClientAPI.GetUserData(request, result => { OnDataRecieve(result, key); }, OnError);
    }
    void OnDataRecieve(GetUserDataResult result, string key)
    {
        string userData = result.Data[key].Value;
        EventCenter.Broadcast(FunctionType.UpdateRivalRecord, userData);
    }
}
