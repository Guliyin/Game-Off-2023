using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class FinishUI : MonoBehaviour
{
    [SerializeField] TMP_Text ranknTime;
    [SerializeField] TMP_Text recordTime;
    [SerializeField] TMP_Text rivalInfo;
    private void OnEnable()
    {
        EventCenter.AddListener<OnlinePlayerInfo>(FunctionType.UpdateRivalInfo, UpdateRivalInfo);
        EventCenter.AddListener(FunctionType.LeaderboardSentSuccessful, UpdateLeaderboardCallBack);
        EventCenter.AddListener<OnlinePlayerInfo>(FunctionType.UpdatePlayerInfo, UpdatePlayerInfo);
    }
    void UpdateLeaderboardCallBack()
    {
        PlayfabManager.Instance.GetLeaderboardAround(SceneManager.GetActiveScene().name, true);
    }
    void UpdateRivalInfo(OnlinePlayerInfo info)
    {
        print(info.Name + " " + info.Value);
        rivalInfo.text = "Next rival - #" + info.Position + " " + info.Name + "\n" + (info.Value / 1000.0f * -1).ToString("0.000") + "s";
    }
    void UpdatePlayerInfo(OnlinePlayerInfo info)
    {
        float time = FindObjectOfType<PlayerRecorder>().time;
        ranknTime.text = "Your time - " + time.ToString("0.000") + "s";
        recordTime.text = "Your best - #" + info.Position + " - " + (info.Value / 1000.0f) * -1 + "s";
    }
    private void OnDisable()
    {
        EventCenter.RemoveListener<OnlinePlayerInfo>(FunctionType.UpdateRivalInfo, UpdateRivalInfo);
        EventCenter.RemoveListener(FunctionType.LeaderboardSentSuccessful, UpdateLeaderboardCallBack);
        EventCenter.RemoveListener<OnlinePlayerInfo>(FunctionType.UpdatePlayerInfo, UpdatePlayerInfo);
    }
}
