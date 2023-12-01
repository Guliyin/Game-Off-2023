using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShadowPlayer : MonoBehaviour
{
    [SerializeField] bool isRecord;
    [SerializeField] Object jsonFile;

    List<Vector3> pos;
    int fixedFrameCount;
    bool playing;
    string sr = "";

    private void OnEnable()
    {
        EventCenter.AddListener(FunctionType.StartPlaying, StartPlaying);
    }
    private void Start()
    {
        if (isRecord)
        {
            string directory = Application.persistentDataPath + "/Json/";
            string path = directory + SceneManager.GetActiveScene().name + "_Record.json";
            if (File.Exists(path))
            {
                sr = File.ReadAllText(path);
            }
        }
        else
        {
            sr = jsonFile.ToString();
        }
        if (sr != "")
        {
            SaveFile jsonList = JsonUtility.FromJson<SaveFile>(sr);
            pos = jsonList.posList;
            float scale = jsonList.scale;

            TrailRenderer trailRenderer = GetComponent<TrailRenderer>();
            trailRenderer.startWidth = scale;
            trailRenderer.endWidth = scale * 0.5f;
            transform.localScale = new Vector3(scale, scale, scale);
            transform.position = pos[0];
        }

    }

    void StartPlaying()
    {
        if (sr != "")
        {
            playing = true;
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<TrailRenderer>().enabled = true;
            GetComponentInChildren<MeshRenderer>().enabled = true;
        }
    }
    private void Update()
    {
        if (!playing) return;

        if (fixedFrameCount+1 < pos.Count)
        {
            float distance = Vector3.Distance(transform.position, pos[fixedFrameCount]);
            transform.position = Vector3.MoveTowards(transform.position, pos[fixedFrameCount], Time.unscaledDeltaTime / (Time.fixedDeltaTime / Time.timeScale) * distance);
        }
        else
        {
            transform.position = pos[fixedFrameCount-1];
        }
    }
    private void FixedUpdate()
    {
        if (!playing || fixedFrameCount >= pos.Count) return;

        fixedFrameCount++;
    }
    private void OnDisable()
    {
        EventCenter.RemoveListener(FunctionType.StartPlaying, StartPlaying);
    }
}
