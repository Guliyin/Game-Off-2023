using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedArea : MonoBehaviour
{
    [Range(0,1)]
    [SerializeField] float decelerate;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Rigidbody2D>() != null)
        {
            collision.GetComponent<Rigidbody2D>().velocity *= decelerate;
        }
    }
}
