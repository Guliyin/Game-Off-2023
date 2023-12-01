using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using System.IO;

public class PlayerGrip : MonoBehaviour
{
    [SerializeField] SpriteRenderer crossHair;
    [SerializeField] LayerMask layerMask;
    [SerializeField] Material lineAim;
    [SerializeField] Material lineGrip;
    [SerializeField] ParticleSystem partical;

    [Header("–°«Ú Ù–‘")]
    [Range(0.5f, 2)]
    [SerializeField] float scale = 1;


    Camera cam;
    Rigidbody2D rb;
    LineRenderer lineRenderer;
    TrailRenderer trailRenderer;
    AudioSource audioSource;
    CustomPlayerInput input;

    Vector3 hitPoint;
    public Vector3 gripPoint;
    bool isGrippling;

    [SerializeField] float hookLength = 15;
    float lineForce;
    float springDistance = 3;

    [HideInInspector] public bool isBulletTime;
    private void OnEnable()
    {
        EventCenter.AddListener(FunctionType.EndPlaying, DisableInputs);
    }

    private void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<CustomPlayerInput>();
        trailRenderer = GetComponent<TrailRenderer>();
        lineRenderer = GetComponentInChildren<LineRenderer>();
        audioSource = GetComponent<AudioSource>();

        input.EnableGameplayInputs();

        string path = Application.persistentDataPath + "/Json/PlayerInfo.json";
        if (File.Exists(path))
        {
            string sr = File.ReadAllText(path);
            PlayerInfo info = JsonUtility.FromJson<PlayerInfo>(sr);

            scale = info.Scale;
        }
        else
        {
            scale = 1;
        }

        rb.drag = 0.15f * scale;
        lineForce = Mathf.Pow(scale, 1.90f) * 40;
        lineRenderer.startWidth = scale * 0.1f;
        trailRenderer.startWidth = scale;
        trailRenderer.endWidth = scale * 0.5f;

        transform.localScale = new Vector3(scale, scale, scale);
    }

    private void Update()
    {
        if (input.restart)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (input.bulletTime)
        {
            StartBulletTime();
        }
        if (input.stopBulletTime)
        {
            EndBuuletTime();
        }
        if (input.gravityUp)
        {
            ChangeGravity(-1);
        }
        if (input.gravityDown)
        {
            ChangeGravity(1);
        }
        if (input.gamePause)
        {
            EventCenter.Broadcast(FunctionType.PauseGame);
            DisableInputs();
            Time.timeScale = 0;
        }

        Vector2 dir;
        if (CustomPlayerInput.CURRENT_CONTROL_SCHEME == CustomPlayerInput.MNK_CONTROL_SCHEME)
        {
            dir = cam.ScreenToWorldPoint(input.aim) - transform.position;
        }
        else
        {
            dir = input.aimPad;
        }
        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, dir, hookLength, layerMask);
        hitPoint = hit.point;

        if (hit.transform == null && !isGrippling)
        {
            crossHair.color = Color.grey;
            gripPoint = transform.position + (Vector3)dir.normalized * hookLength;
            crossHair.transform.position = gripPoint;
        }
        else if (hit.transform != null && !isGrippling)
        {
            if (1 << hit.transform.gameObject.layer == LayerMask.GetMask("GreyWall"))
            {
                crossHair.color = Color.grey;
            }
            else
            {
                crossHair.color = Color.red;
            }
            gripPoint = hitPoint;
            crossHair.transform.position = gripPoint;
        }

        if (input.fire && hit.transform != null && 1 << hit.transform.gameObject.layer == LayerMask.GetMask("Wall"))
        {
            ShotGripple();
        }
        if (input.release)
        {
            lineRenderer.material = lineAim;
            isGrippling = false;
        }
        DrawLine();
    }
    private void FixedUpdate()
    {
        if (isGrippling)
        {
            Vector2 dirLine = gripPoint - transform.position;
            rb.AddForce(dirLine.normalized * lineForce * (Mathf.Min(springDistance, dirLine.magnitude) / springDistance), ForceMode2D.Force);
        }
    }
    private void ChangeGravity(int n)
    {
        rb.gravityScale += n;
        rb.gravityScale = Mathf.Clamp(rb.gravityScale, -2, 2);

        EventCenter.Broadcast(FunctionType.UpdateGravityBG, rb.gravityScale);
    }
    void StartBulletTime()
    {
        isBulletTime = true;
        DOTween.To(() => Time.timeScale, x => Time.timeScale = x, 0.4f, 0.2f);
        EventCenter.Broadcast(FunctionType.StartBulletTime);
    }
    public void EndBuuletTime()
    {
        if (!isBulletTime) return;
        isBulletTime = false;
        DOTween.To(() => Time.timeScale, x => Time.timeScale = x, 1f, 0.2f);
        EventCenter.Broadcast(FunctionType.EndBulletTime);
    }

    void ShotGripple()
    {
        isGrippling = true;
        gripPoint = hitPoint;
        lineRenderer.material = lineGrip;
        crossHair.transform.position = gripPoint;

        partical.transform.position = gripPoint;
        partical.Play();

        audioSource.PlayOneShot(audioSource.clip);
    }

    void DrawLine()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, gripPoint);
    }
    void DisableInputs()
    {
        isGrippling = false;
        input.DisableGameplayInputs();
        crossHair.gameObject.SetActive(false);
        lineRenderer.enabled = false;
    }
    void EnableInputs()
    {
        input.EnableGameplayInputs();
        crossHair.gameObject.SetActive(true);
        lineRenderer.enabled = true;
    }
    public void GameContinue()
    {
        EventCenter.Broadcast(FunctionType.ContinueGame);
        EnableInputs();
        Time.timeScale = 1f;
    }
    private void OnDisable()
    {
        EventCenter.RemoveListener(FunctionType.EndPlaying, DisableInputs);
    }
}
