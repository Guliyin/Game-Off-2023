using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PlayerGrip : MonoBehaviour
{
    [SerializeField] SpriteRenderer corssHair;
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
    CustomPlayerInput input;

    Vector3 hitPoint;
    Vector3 gripPoint;
    bool isGrippling;

    [SerializeField] float hookLength = 15;
    float lineForce;
    float springDistance = 1;

    [HideInInspector] public bool isBulletTime;

    private void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<CustomPlayerInput>();
        trailRenderer = GetComponent<TrailRenderer>();
        lineRenderer = GetComponentInChildren<LineRenderer>();

        input.EnableGameplayInputs();

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

        Vector2 dir;
        if (CustomPlayerInput.CURRENT_CONTROL_SCHEME == CustomPlayerInput.MNK_CONTROL_SCHEME)
        {
            dir = cam.ScreenToWorldPoint(input.aim) - transform.position;
        }
        else
        {
            dir = input.aimPad;
            print(input.aimPad);
        }
        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, dir, hookLength, layerMask);
        hitPoint = hit.point;

        if (hit.transform == null && !isGrippling)
        {
            corssHair.color = Color.grey;
            gripPoint = transform.position + (Vector3)dir.normalized * hookLength;
            corssHair.transform.position = gripPoint;
        }
        else if (hit.transform != null && !isGrippling)
        {
            corssHair.color = Color.red;
            gripPoint = hitPoint;
            corssHair.transform.position = gripPoint;
        }

        if (input.fire && hit.transform != null)
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
        corssHair.transform.position = gripPoint;

        partical.transform.position = gripPoint;
        partical.Play();
    }

    void DrawLine()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, gripPoint);
    }
}
