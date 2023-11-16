using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class JsonList<T>
{
    public List<T> list;
    public JsonList(List<T> list) => this.list = list;
}

public class PlayerRecorder : MonoBehaviour
{
    [SerializeField] Transform player;

    public List<Vector3> positions = new List<Vector3>();

    private void FixedUpdate()
    {
        positions.Add(player.position);
    }
    public void Save()
    {
        string json = JsonUtility.ToJson(new JsonList<Vector3>(positions), true);
        File.WriteAllText(Application.dataPath + "/Json/JsonRecord", json);
    }
}
