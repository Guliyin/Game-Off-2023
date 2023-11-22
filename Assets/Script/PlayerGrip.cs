using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerGrip : MonoBehaviour
{
    [SerializeField] SpriteRenderer corssHair;
    [SerializeField] LayerMask layerMask;
    [SerializeField] Material lineAim;
    [SerializeField] Material lineGrip;
    [SerializeField] ParticleSystem partical;


    [Header("–°«Ú Ù–‘")]
    [Range(5, 20)]
    [SerializeField] float hookLength = 5;
    [Range(10,200)]
    [SerializeField] float lineForce = 20;
    [Range(0.5f, 2)]
    [SerializeField] float mass = 1;
    [Range(0.5f,2)]
    [SerializeField] float scale = 1;

    Camera cam;
    Rigidbody2D rb;
    LineRenderer lineRenderer;

    Vector3 hitPoint;
    Vector3 gripPoint;
    bool isGrippling;
    private void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        lineRenderer = GetComponentInChildren<LineRenderer>();

        //rb.mass = mass;
        rb.drag = 0.1f * scale;
        transform.localScale = new Vector3(scale, scale, scale);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DOTween.To(() => Time.timeScale, x => Time.timeScale = x, 0.5f, 0.2f);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            DOTween.To(() => Time.timeScale, x => Time.timeScale = x, 1f, 0.2f);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            DOTween.To(() => rb.gravityScale, x => rb.gravityScale = x, 0, 0.2f);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            DOTween.To(() => rb.gravityScale, x => rb.gravityScale = x, 2, 0.2f);
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            DOTween.To(() => rb.gravityScale, x => rb.gravityScale = x, 1, 0.2f);
        }

        Vector2 dir = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
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

        if (Input.GetMouseButtonDown(0) && hit.transform != null)
        {
            gripPoint = hitPoint;
            ShotGripple(gripPoint);
            isGrippling = true;
            lineRenderer.material = lineGrip;
            corssHair.transform.position = gripPoint;
        }
        if (Input.GetMouseButtonUp(0))
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
            rb.AddForce(dirLine.normalized * lineForce, ForceMode2D.Force);
        }
    }

    void ShotGripple(Vector3 position)
    {
        rb.AddForce((position - transform.position).normalized * -(lineForce / 16), ForceMode2D.Impulse);

        partical.transform.position = position;
        partical.Play();
    }

    void DrawLine()
    {
        lineRenderer.SetPosition(0,transform.position);
        lineRenderer.SetPosition(1,gripPoint);
    }
}
