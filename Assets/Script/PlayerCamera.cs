using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] Transform cameraPoint;
    [SerializeField] Transform cameraFollowPoint;
    [SerializeField] float distance;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        cameraPoint.localPosition = rb.velocity.normalized * distance;
        cameraFollowPoint.localPosition = Vector3.MoveTowards(cameraFollowPoint.localPosition, cameraPoint.localPosition, Time.deltaTime*10);
    }
}
