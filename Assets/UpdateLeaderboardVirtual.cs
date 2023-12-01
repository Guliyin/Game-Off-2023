using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpdateLeaderboardVirtual : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayfabManager.Instance.SendLeaderboard(9999999, SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
