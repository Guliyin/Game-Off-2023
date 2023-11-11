using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerGrip : MonoBehaviour
{
    [SerializeField] GameObject g;
    [SerializeField] LayerMask layerMask;
    [SerializeField] float lineForce;

    Camera cam;
    Rigidbody2D rb;
    LineRenderer lineRenderer;

    Vector3 hitPoint;
    bool isGrippling;

    private void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        lineRenderer = GetComponentInChildren<LineRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Vector2 dir = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            RaycastHit2D hit;

            hit = Physics2D.Raycast(transform.position, dir, 20, layerMask);

            if (hit.transform == null) return;

            lineRenderer.enabled = true;
            hitPoint = hit.point;
            print(hit.point + " " + hit.transform.name);

        }
        if (Input.GetMouseButton(0))
        {
            DrawLine();
        }
        if (Input.GetMouseButtonUp(0))
        {
            lineRenderer.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            DOTween.To(() => Time.timeScale, x => Time.timeScale = x, 0.2f, 0.05f);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            DOTween.To(() => Time.timeScale, x => Time.timeScale = x, 1f, 0.05f);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            DOTween.To(() => rb.gravityScale, x => rb.gravityScale = x, 0, 0.05f);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            DOTween.To(() => rb.gravityScale, x => rb.gravityScale = x, 1, 0.05f);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            DOTween.To(() => rb.gravityScale, x => rb.gravityScale = x, 2, 0.05f);
        }
    }
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 dir = hitPoint - transform.position;
            rb.AddForce(dir.normalized * lineForce, ForceMode2D.Force);
        }
    }

    void DrawLine()
    {
        lineRenderer.SetPosition(0,transform.position);
        lineRenderer.SetPosition(1,hitPoint);
    }

    private void OnDrawGizmos()
    {
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Gizmos.DrawRay(transform.position, dir);
    }
}
