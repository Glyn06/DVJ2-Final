using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour {

    public Rigidbody2D rb;
    public float speed = 0.1f;
    [HideInInspector]
    public Vector2 direction;
    public float dieTime = 5;

    private void Start()
    {
        Destroy(gameObject, dieTime);
    }

    private void FixedUpdate()
    {
        Move(direction);
    }

    public void Move(Vector2 dir) {
        rb.MovePosition(rb.position + (dir * speed));
    }
}
