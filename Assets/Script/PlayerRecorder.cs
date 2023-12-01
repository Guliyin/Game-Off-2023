using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SaveFile
{
    public float time;
    public float scale;
    public List<Vector3> posList;


    public SaveFile(List<Vector3> _list, float _time, float _scale)
    {
        posList = _list;
        time = _time;
        scale = _scale;
    }
}

public class PlayerRecorder : MonoBehaviour
{

    [SerializeField] bool isRecording;
    [SerializeField] TMP_Text timer;

    Transform player;

    List<Vector3> positions = new List<Vector3>();
    public float time;
    bool recording;

    private void OnEnable()
    {
        EventCenter.AddListener(FunctionType.StartPlaying, StartRecord);
        EventCenter.AddListener(FunctionType.EndPlaying, Save);
        EventCenter.AddListener(FunctionType.LeaderboardSentSuccessful, LeaderboardSentCallBack);
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        if (recording)
            timer.text = "Your time: " + time.ToString("0.000");
    }
    private void FixedUpdate()
    {
        if (recording)
        {
            time += Time.fixedDeltaTime;
            positions.Add(player.position);
        }
    }
    void StartRecord()
    {
        recording = true;
    }
    void Save()
    {
        recording = false;
        timer.text = "TIME: " + time.ToString("0.000");
        positions.Add(player.position);

        string json;
        if (isRecording)
        {
            json = JsonUtility.ToJson(new SaveFile(positions, time, player.transform.localScale.x), true);
            File.WriteAllText(Application.persistentDataPath + "/Json/" + SceneManager.GetActiveScene().name + "_" + time.ToString("0.000") + "_" + System.DateTime.Now.ToString("yyyy-M-d-HH-mm-ss") + ".json", json);
        }
        string directory = Application.persistentDataPath + "/Json/";
        string path = directory + SceneManager.GetActiveScene().name + "_Record.json";
        if (File.Exists(path))
        {
            string sr = File.ReadAllText(path);
            SaveFile saveFile = JsonUtility.FromJson<SaveFile>(sr);
            json = JsonUtility.ToJson(new SaveFile(positions, time, player.transform.localScale.x), true);
            if (saveFile.time > time)
            {
                File.WriteAllText(path, json);
                PlayfabManager.Instance.SendRecord(SceneManager.GetActiveScene().name, json);
            }
        }
        else
        {
            Directory.CreateDirectory(directory);
            json = JsonUtility.ToJson(new SaveFile(positions, time, player.transform.localScale.x), true);
            File.WriteAllText(path, json);
            PlayfabManager.Instance.SendRecord(SceneManager.GetActiveScene().name, json);
        }
        PlayfabManager.Instance.SendLeaderboard((int)(time * 1000), SceneManager.GetActiveScene().name);
    }
    void LeaderboardSentCallBack()
    {
        PlayfabManager.Instance.GetLeaderBoardPlayerPos(SceneManager.GetActiveScene().name);
    }
    private void OnDisable()
    {
        EventCenter.RemoveListener(FunctionType.StartPlaying, StartRecord);
        EventCenter.RemoveListener(FunctionType.EndPlaying, Save);
        EventCenter.AddListener(FunctionType.LeaderboardSentSuccessful, LeaderboardSentCallBack);
    }
}
