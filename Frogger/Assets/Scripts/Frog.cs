using System.Collections;
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
[HideInInspector] public GameObject target;
                  public bool isTouchingWater = false;
                  public bool isTouchingWaterOBJ = false;
    public float dieTime = 0.1f;
    private float timer = 0;

    Vector3 wrld;
    float half_sz;

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
        if (target != null)
        {
            transform.position = target.transform.position;
        }
        else if (isTouchingWater && !isTouchingWaterOBJ)
        {
            timer += Time.deltaTime;
        }
        if (timer >= dieTime)
        {
            Die();
            timer = 0;
        }
        Movement();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("m_water"))
        {
            isTouchingWater = true;
        }

        if (collision.CompareTag("m_lily"))
        {
            isTouchingWaterOBJ = true;
            target = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTouchingWater = false;
        isTouchingWaterOBJ = false;
        target = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("m_car"))
        {
            Die();
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
