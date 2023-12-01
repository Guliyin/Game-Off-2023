using System.Collections;
using System.Collections.Generic;
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
        EventCenter.AddListener<OnlinePlayerInfo>(FunctionType.UpdatePlayerInfo, UpdatePlayerInfo);
    }
    void UpdateRivalInfo(OnlinePlayerInfo info)
    {
        rivalInfo.text = "Next rival - #" + info.Position + " " + info.Name + "\n" + (info.Value / 1000.0f).ToString("0.000") + "s";
    }
    void UpdatePlayerInfo(OnlinePlayerInfo info)
    {
        float time = FindObjectOfType<PlayerRecorder>().time;
        ranknTime.text = "Your time - " + time.ToString("0.000") + "s";
        recordTime.text = "Your best - #" + info.Position + " - " + (info.Value / 1000.0f) + "s";
    }
    private void OnDisable()
    {
        EventCenter.RemoveListener<OnlinePlayerInfo>(FunctionType.UpdateRivalInfo, UpdateRivalInfo);
    }
}
