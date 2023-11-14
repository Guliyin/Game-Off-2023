using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerRecorder : MonoBehaviour
{
    [SerializeField] Transform player;

    public List<Vector3> positions = new List<Vector3>();

    public List<string> test = new List<string>();

    public int a = 10;

    void Start()
    {
        test.Add("A");
        test.Add("B");
        test.Add("C");
    }
    private void FixedUpdate()
    {
        positions.Add(player.position);
    }
    public void Save()
    {
        string json = JsonUtility.ToJson(a);
        File.WriteAllText(Application.dataPath + "test.json", json);
        print(json);
    }
}
