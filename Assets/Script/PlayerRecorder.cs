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
    float time;
    bool recording;

    private void OnEnable()
    {
        EventCenter.AddListener(FunctionType.StartPlaying, StartRecord);
        EventCenter.AddListener(FunctionType.EndPlaying, Save);
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        if(recording)
        timer.text = "TIME: " + time.ToString("0.00");
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
        positions.Add(player.position);

        if (isRecording)
        {
            string json = JsonUtility.ToJson(new SaveFile(positions, time, player.transform.localScale.x), true);
            File.WriteAllText(Application.persistentDataPath + "/Json/" + SceneManager.GetActiveScene().name + "_" + time.ToString("0.000") + "_" + System.DateTime.Now.ToString("yyyy-M-d-HH-mm-ss") + ".json", json);
        }
        else
        {
            string directory = Application.persistentDataPath + "/Json/";
            string path = directory + SceneManager.GetActiveScene().name + "_Record.json";
            if (File.Exists(path))
            {
                string sr = File.ReadAllText(path);
                SaveFile saveFile = JsonUtility.FromJson<SaveFile>(sr);
                if (saveFile.time > time)
                {
                    string json = JsonUtility.ToJson(new SaveFile(positions, time, player.transform.localScale.x), true);
                    File.WriteAllText(path, json);
                }
            }
            else
            {
                Directory.CreateDirectory(directory);
                string json = JsonUtility.ToJson(new SaveFile(positions, time, player.transform.localScale.x), true);
                File.WriteAllText(path, json);
            }
        }
    }
    private void OnDisable()
    {
        EventCenter.RemoveListener(FunctionType.StartPlaying, StartRecord);
        EventCenter.RemoveListener(FunctionType.EndPlaying, Save);
    }
}
