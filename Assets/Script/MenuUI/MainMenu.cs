using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

[System.Serializable]
public struct SceneInfo
{
    public int num;
    public string name;
    public Sprite image;
}

public class MainMenu : MonoBehaviour
{
    RectTransform rectTransform;
    public SceneInfo[] sceneInfo;
    public int curScene = 1;

    private void OnEnable()
    {
        EventCenter.AddListener(FunctionType.LoginSuccessful, StartGame);
    }

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void MainToLevel()
    {
        rectTransform.DOAnchorPosX(-1920, 0.35f);
    }
    public void LevelToMain()
    {
        rectTransform.DOAnchorPosX(0, 0.35f);
    }
    public void MainToCredit()
    {
        rectTransform.DOAnchorPosY(1080, 0.35f);
    }
    public void CreditToMain()
    {
        rectTransform.DOAnchorPosY(0, 0.35f);
    }
    public void StartGame()
    {
        rectTransform.DOAnchorPosX(-3840, 0.35f);
        StartCoroutine(Timer());
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.35f);
        SceneManager.LoadScene(curScene);
    }
    private void OnDisable()
    {
        EventCenter.RemoveListener(FunctionType.LoginSuccessful, StartGame);
    }
}
