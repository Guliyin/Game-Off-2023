using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

    [ExecuteInEditMode]
public class PlayerGrip : MonoBehaviour
{
    [SerializeField] SpriteRenderer corssHair;
    [SerializeField] LayerMask layerMask;


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

        rb.mass = mass;
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
            corssHair.transform.position = transform.position + (Vector3)dir.normalized * hookLength;
            return;
        }
        else if (hit.transform != null && !isGrippling)
        {
            corssHair.color = Color.red;
            corssHair.transform.position = hitPoint;
        }

        if (Input.GetMouseButtonDown(0))
        {
            gripPoint = hitPoint;
            isGrippling = true;
            lineRenderer.enabled = true;
            corssHair.transform.position = gripPoint;
        }
        if (Input.GetMouseButton(0))
        {
            DrawLine();
        }
        if (Input.GetMouseButtonUp(0))
        {
            lineRenderer.enabled = false;
            isGrippling = false;
        }
    }
    private void FixedUpdate()
    {
        if (isGrippling)
        {
            Vector2 dirLine = gripPoint - transform.position;
            rb.AddForce(dirLine.normalized * lineForce, ForceMode2D.Force);
        }
    }

    void DrawLine()
    {
        lineRenderer.SetPosition(0,transform.position);
        lineRenderer.SetPosition(1,gripPoint);
    }

    private void OnDrawGizmos()
    {
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Gizmos.DrawRay(transform.position, dir.normalized * hookLength);
    }
}
