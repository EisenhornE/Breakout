using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float horizontalInput;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(horizontalInput * 10, 0);
    }
}
