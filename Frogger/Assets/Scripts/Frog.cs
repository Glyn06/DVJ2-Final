﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour {

    #region Singleton
    public static Frog instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

                  public Rigidbody2D rb;
                  public float movementQuantity = 0.3f;
                  public int lives = 3;
[HideInInspector] public Vector2 startingPos;
public bool isTouchingWater = false;
public bool isTouchingLily = false;

    Vector3 wrld;
    float half_sz;
    GameObject target;

    private void Start()
    {
        wrld = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, 0.0f));
        half_sz = gameObject.GetComponent<Renderer>().bounds.size.x / 2;
        startingPos = rb.position;
    }

    void Update () {
        if (lives <= 0)
        {
            Debug.Log("Game Over");
        }
        Bounds();
    }

    private void LateUpdate()
    {
        if (isTouchingLily && isTouchingWater)
        {
            transform.position = target.transform.position;
        }
        else if (!isTouchingLily && isTouchingWater)
        {
            Die();
        }

        Movement();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("m_lily"))
        {
            target = collision.gameObject;
            isTouchingLily = true;
        }

        if (collision.CompareTag("m_water"))
        {
            isTouchingWater = true;
        }

        if (collision.gameObject.CompareTag("m_car"))
        {
            Die();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       if (collision.CompareTag("m_lily"))
       {
           target = null;
           isTouchingLily = false;
       }

       if (collision.CompareTag("m_water"))
       {
           isTouchingWater = false;
       }
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
    void Die() {
        lives--;
        rb.MovePosition(startingPos);
    }
}
