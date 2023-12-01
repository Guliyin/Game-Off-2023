using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UIController : MonoBehaviour
{
    [SerializeField] TMP_Text scaleText;
    [SerializeField] TMP_Text rivalTimeText;
    [SerializeField] Image bulletTime;
    [SerializeField] Slider slider;
    [SerializeField] RectTransform pauseUI;
    [SerializeField] RectTransform finishUI;
    [SerializeField] RectTransform blackCover;
    RectTransform sliderRectTransform;
    CanvasGroup sliderCanvasGroup;
    AudioSource audioSource;

    PlayerGrip player;
    Rigidbody2D rb;

    [Range(1, 10)]
    [SerializeField] float MaxBTCoolDown = 5;

    float btCoolDown;

    private void OnEnable()
    {
        EventCenter.AddListener(FunctionType.StartBulletTime, StartBulletTime);
        EventCenter.AddListener(FunctionType.EndBulletTime, EndBulletTime);
        EventCenter.AddListener(FunctionType.PauseGame, ShowPause);
        EventCenter.AddListener(FunctionType.ContinueGame,HidePause);
        EventCenter.AddListener(FunctionType.EndPlaying, ShowEnd);
    }
    private void Start()
    {
        btCoolDown = MaxBTCoolDown;

        sliderCanvasGroup = slider.GetComponent<CanvasGroup>();
        sliderRectTransform = slider.GetComponent<RectTransform>();
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGrip>();
        rb = player.GetComponent<Rigidbody2D>();

        blackCover.DOAnchorPosX(-1920, 0.35f);
    }
    void Update()
    {
        scaleText.text = "TimeScale:" + Time.timeScale.ToString("0.0") + "\n\nGravityScale:" + rb.gravityScale.ToString("0.0");

        if (player.isBulletTime)
        {
            btCoolDown -= Time.unscaledDeltaTime;
            if(btCoolDown <= 0)
            {
                player.EndBuuletTime();
            }
        }
        else
        {
            btCoolDown += Time.unscaledDeltaTime / 2;
            btCoolDown = Mathf.Clamp(btCoolDown, 0, MaxBTCoolDown);
        }
        slider.value = btCoolDown / MaxBTCoolDown;
    }
    public void InitRivalTime(float time)
    {
        rivalTimeText.text = "Rival's time: " + time.ToString("0.000");
    }
    void StartBulletTime()
    {
        sliderRectTransform.DOAnchorMin(new Vector2(0.5f, 0.5f), 0.15f);
        sliderRectTransform.DOAnchorMax(new Vector2(0.5f, 0.5f), 0.15f);
        sliderRectTransform.DOAnchorPos(new Vector2(0, -200), 0.15f);
        sliderRectTransform.DOSizeDelta(new Vector2(1200, 100), 0.15f);

        sliderCanvasGroup.DOFade(0.3f, 0.2f);
        bulletTime.DOFade(1, 0.2f);
    }
    void EndBulletTime()
    {
        sliderRectTransform.DOAnchorMin(new Vector2(0f, 1f), 0.15f);
        sliderRectTransform.DOAnchorMax(new Vector2(0f, 1f), 0.15f);
        sliderRectTransform.DOAnchorPos(new Vector2(200, -100), 0.15f);
        sliderRectTransform.DOSizeDelta(new Vector2(400, 50), 0.15f);

        sliderCanvasGroup.DOFade(1f, 0.2f);
        bulletTime.DOFade(0, 0.2f);
    }
    void ShowPause()
    {
        pauseUI.gameObject.SetActive(true);
    }
    void HidePause()
    {
        pauseUI.gameObject.SetActive(false);
    }
    void ShowEnd()
    {
        audioSource.Play();

        Sequence sequence = DOTween.Sequence();
        sequence.Append(finishUI.DOAnchorPosX(-100, 0.2f));
        sequence.Append(finishUI.DOAnchorPosX(0, 0.1f));
        sequence.Play();
    }
    private void OnDisable()
    {
        EventCenter.RemoveListener(FunctionType.StartBulletTime, StartBulletTime);
        EventCenter.RemoveListener(FunctionType.EndBulletTime, EndBulletTime);
        EventCenter.RemoveListener(FunctionType.PauseGame, ShowPause);
        EventCenter.RemoveListener(FunctionType.ContinueGame, HidePause);
        EventCenter.RemoveListener(FunctionType.EndPlaying, ShowEnd);
    }
}
