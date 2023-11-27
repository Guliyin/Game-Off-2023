using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Rigidbody2D>().velocity *= 0.5f;
        }
    }
}
