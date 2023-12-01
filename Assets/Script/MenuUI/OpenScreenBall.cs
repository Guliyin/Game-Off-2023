using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenScreenBall : MonoBehaviour
{
    [SerializeField] Object jsonFile;

    List<Vector3> pos;
    int fixedFrameCount;

    void Start()
    {
        string sr = "";
        sr = jsonFile.ToString();
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
    private void Update()
    {
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
        if (fixedFrameCount >= pos.Count)
        {
            fixedFrameCount = 0;
        }

        fixedFrameCount++;
    }
}
