using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour
{
    private static GameMgr instance;
    public static GameMgr Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameMgr>();
            }
            return instance;
        }
    }
    [SerializeField] AudioClip pDownClip;
    [SerializeField] AudioClip pOnClip;

    RectTransform triangleRt;
    AudioSource audioSource;
    private void Start()
    {
        triangleRt = GameObject.FindGameObjectWithTag("UITriangle").GetComponent<RectTransform>();
        audioSource = GetComponent<AudioSource>();
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void GameContinue()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGrip>().GameContinue();
    }
    public void BtnClickedSound()
    {
        audioSource.clip = pDownClip;
        audioSource.Play();
    }
    public void PointerOn(RectTransform transform)
    {
        if(transform.GetComponent<Button>()&& transform.GetComponent<Button>().interactable)
        {
            audioSource.clip = pOnClip;
            audioSource.Play();

            triangleRt.gameObject.SetActive(true);
            triangleRt.SetParent(transform);
            triangleRt.anchoredPosition = new Vector2(-10, 0);
        }
    }
    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void NextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
