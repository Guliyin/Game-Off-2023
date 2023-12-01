using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;


public class MenuLevel : MonoBehaviour
{
    [SerializeField] TMP_Text levelName;
    [SerializeField] Image thumbNail;
    [SerializeField] TMP_Text yourText;
    [SerializeField] TMP_Text rivalText;

    [SerializeField] MainMenu menu;

    private void OnEnable()
    {
        EventCenter.AddListener<OnlinePlayerInfo>(FunctionType.UpdateRivalInfo, UpdateRivalInfo);
        EventCenter.AddListener<OnlinePlayerInfo>(FunctionType.UpdatePlayerInfo, UpdatePlayerInfo);
    }
    public void LoginSuccessful()
    {
        UpdateUI(menu.sceneInfo[0]);
    }
    public void LevelButtonSelect(Button btn)
    {
        int n = int.Parse(btn.name) - 1;
        menu.curScene = n + 1;
        UpdateUI(menu.sceneInfo[n]);

    }
    void UpdateUI(SceneInfo curSceneInfo)
    {
        levelName.text = curSceneInfo.name;
        thumbNail.sprite = curSceneInfo.image;

        bool isPlayer;
        string path = Application.persistentDataPath + "/Json/" + curSceneInfo.name + "_Record.json";
        if (File.Exists(path))
        {
            isPlayer = true;
            PlayfabManager.Instance.GetLeaderBoardPlayerPos(curSceneInfo.name);
        }
        else
        {
            yourText.text = "Never played before\nTime: N/A";
            isPlayer = false;

        }
        PlayfabManager.Instance.GetLeaderboardAround(curSceneInfo.name, isPlayer);
    }
    void UpdatePlayerInfo(OnlinePlayerInfo info)
    {
        yourText.text = "#" + info.Position + " on leaderboard\nTime: " + (info.Value / 1000.0f * -1).ToString("0.000") + "s";
    }
    void UpdateRivalInfo(OnlinePlayerInfo info)
    {
        rivalText.text = "Next rival: #" + info.Position + " - " + info.Name + "\n" + (info.Value / 1000.0f * -1).ToString("0.000") + "s";
    }
    private void OnDisable()
    {
        EventCenter.RemoveListener<OnlinePlayerInfo>(FunctionType.UpdateRivalInfo, UpdateRivalInfo);
        EventCenter.RemoveListener<OnlinePlayerInfo>(FunctionType.UpdatePlayerInfo, UpdatePlayerInfo);
    }
}
