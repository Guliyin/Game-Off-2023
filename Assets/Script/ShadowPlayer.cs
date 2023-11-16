using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ShadowPlayer : MonoBehaviour
{
    List<Vector3> pos;
    int fixedFrameCount;
    void Start()
    {
        string path = Application.dataPath + "/Json/JsonRecord";
        string sr = File.ReadAllText(path);
        JsonList<Vector3> jsonList = JsonUtility.FromJson<JsonList<Vector3>>(sr);
        pos = jsonList.list;
    }

    private void FixedUpdate()
    {
        if (fixedFrameCount >= pos.Count) return;

        transform.position = pos[fixedFrameCount];
        fixedFrameCount++;
    }
}
