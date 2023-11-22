using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

[System.Serializable]
public class SaveFile
{
    public float time;
    public List<Vector3> posList;

    public SaveFile(List<Vector3> _list, float _time)
    {
        posList = _list;
        time = _time;
    }
}

public class PlayerRecorder : MonoBehaviour
{
    [SerializeField] bool isRecording;
    [SerializeField] Transform player;
    [SerializeField] TMP_Text timer;

    List<Vector3> positions = new List<Vector3>();
    float time;
    private void Start()
    {
        time = Time.time;
    }
    private void Update()
    {
        timer.text = "TIME: " + (Time.time - time).ToString("0.000");
    }
    private void FixedUpdate()
    {
        positions.Add(player.position);
    }
    public void Save()
    {
        time = Time.time - time;
        print(time);

        positions.Add(player.position);

        if (isRecording)
        {
            string json = JsonUtility.ToJson(new SaveFile(positions, time), true);
            File.WriteAllText(Application.dataPath + "/Json/" + time.ToString() + "_" + System.DateTime.Now.ToString("yyyy-M-d-HH-mm-ss") + ".json", json);
        }
        else
        {
            string path = Application.dataPath + "/Json/JsonRecord.json";
            string sr = File.ReadAllText(path);
            SaveFile saveFile = JsonUtility.FromJson<SaveFile>(sr);
            if (saveFile.time > time)
            {
                string json = JsonUtility.ToJson(new SaveFile(positions, time), true);
                File.WriteAllText(Application.dataPath + "/Json/JsonRecord.json", json);
            }
        }
    }
}
