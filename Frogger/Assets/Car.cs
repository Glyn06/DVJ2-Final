using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {

    public Rigidbody2D rb;
    public float speed = 0.1f;
    [HideInInspector]
    public Vector2 direction;

    private void Start()
    {
        Destroy(gameObject, 5);
    }

    private void LateUpdate()
    {
        Move(direction);
    }

    public void Move(Vector2 dir) {
        rb.MovePosition(rb.position + (dir * speed));
    }
}
