using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class ShadowRival : MonoBehaviour
{
    string id;
    string displayName;
    string record;
    int fixedFrameCount;
    bool playing;

    SaveFile saveFile;

    List<Vector3> pos = new List<Vector3>();
    float scale;
    float time;

    private void OnEnable()
    {
        EventCenter.AddListener<OnlinePlayerInfo>(FunctionType.UpdateRivalInfo, GetRivalInfoRecall);
        EventCenter.AddListener<string>(FunctionType.UpdateRivalRecord, GetRivalRecordRecall);
        EventCenter.AddListener(FunctionType.StartPlaying, StartPlaying);
        EventCenter.AddListener(FunctionType.EndPlaying, EndPlaying);
    }
    void Start()
    {
        /////////////

        bool isPlayer;
        string path = Application.persistentDataPath + "/Json/" + SceneManager.GetActiveScene().name + "_Record.json";
        if (File.Exists(path))
        {
            isPlayer = true;
        }
        else
        {
            isPlayer = false;
        }

        PlayfabManager.Instance.GetLeaderboardAround(SceneManager.GetActiveScene().name, isPlayer);
    }
    void GetRivalInfoRecall(OnlinePlayerInfo info)
    {
        id = info.PlayfabId;
        displayName = info.Name;
        print(displayName);
        PlayfabManager.Instance.GetUserData(SceneManager.GetActiveScene().name, id);
    }
    void GetRivalRecordRecall(string s)
    {
        record = s;
        saveFile = JsonUtility.FromJson<SaveFile>(record);
        pos = saveFile.posList;
        scale = saveFile.scale;
        time = saveFile.time;

        FindObjectOfType<UIController>().InitRivalTime(time);

        Init();
    }
    void Init()
    {
        GetComponentInChildren<TMP_Text>().text = displayName;
        TrailRenderer trailRenderer = GetComponent<TrailRenderer>();
        trailRenderer.startWidth = scale;
        trailRenderer.endWidth = scale * 0.5f;
        transform.localScale = new Vector3(scale, scale, scale);
        transform.position = pos[0];
    }
    void StartPlaying()
    {
        playing = true;
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<TrailRenderer>().enabled = true;
        GetComponentInChildren<MeshRenderer>().enabled = true;
    }
    void EndPlaying()
    {
        playing = false;
    }
    private void Update()
    {
        if (!playing) return;
        if (pos.Count <= 0) return;

        if (fixedFrameCount + 1 < pos.Count)
        {
            float distance = Vector3.Distance(transform.position, pos[fixedFrameCount]);
            transform.position = Vector3.MoveTowards(transform.position, pos[fixedFrameCount], Time.unscaledDeltaTime / (Time.fixedDeltaTime / Time.timeScale) * distance);
        }
        else
        {
            transform.position = pos[fixedFrameCount - 1];
        }
    }
    private void FixedUpdate()
    {
        if (!playing || (fixedFrameCount >= pos.Count && pos.Count != 0)) return;

        fixedFrameCount++;
    }
    private void OnDisable()
    {
        EventCenter.RemoveListener<OnlinePlayerInfo>(FunctionType.UpdateRivalInfo, GetRivalInfoRecall);
        EventCenter.RemoveListener<string>(FunctionType.UpdateRivalRecord, GetRivalRecordRecall);
        EventCenter.RemoveListener(FunctionType.StartPlaying, StartPlaying);
    }
}
