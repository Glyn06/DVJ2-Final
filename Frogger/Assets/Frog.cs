using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour {

    public Rigidbody2D rb;
    public float movementQuantity;

	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            rb.MovePosition(rb.position + (Vector2.up * movementQuantity));
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            rb.MovePosition(rb.position + (Vector2.down * movementQuantity));
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            rb.MovePosition(rb.position + (Vector2.left * movementQuantity));
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            rb.MovePosition(rb.position + (Vector2.right * movementQuantity));
    }
}
