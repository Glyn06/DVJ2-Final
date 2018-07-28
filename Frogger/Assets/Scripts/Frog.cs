using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour {

    public Rigidbody2D rb;
    public float movementQuantity;

    Vector3 wrld;
    float half_sz;

    private void Start()
    {
        wrld = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, 0.0f));
        half_sz = gameObject.GetComponent<Renderer>().bounds.size.x / 2;
    }
   

    void Update () {
        Movement();
        Bounds();
    }

    void Movement() {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            rb.MovePosition(rb.position + (Vector2.up * movementQuantity));
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            rb.MovePosition(rb.position + (Vector2.down * movementQuantity));
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            rb.MovePosition(rb.position + (Vector2.left * movementQuantity));
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            rb.MovePosition(rb.position + (Vector2.right * movementQuantity));
    }
    void Bounds() {
        if (rb.position.x >= (wrld.x - half_sz))
        {
            rb.MovePosition(rb.position + (Vector2.left * movementQuantity));
        }
        else if (rb.position.x <= (half_sz - wrld.x))
        {
            rb.MovePosition(rb.position + (Vector2.right * movementQuantity));
        }
    }
}
