using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ShadowPlayer : MonoBehaviour
{
    List<Vector3> pos;
    Rigidbody2D rb;
    int fixedFrameCount;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        string path = Application.dataPath + "/Json/JsonRecord.json";
        string sr = File.ReadAllText(path);
        SaveFile jsonList = JsonUtility.FromJson<SaveFile>(sr);
        pos = jsonList.posList;
        
    }
    private void FixedUpdate()
    {
        if (fixedFrameCount >= pos.Count) return;

        rb.position = pos[fixedFrameCount];
        fixedFrameCount++;
    }
}
