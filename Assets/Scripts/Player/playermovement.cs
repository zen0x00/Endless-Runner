using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float forwardSpeed = 6f;
    public float laneDistance = 2f;
    public float smoothSideSpeed = 6f;
    public float jumpForce = 7f;

    public GameObject GameOver;

    Rigidbody rb;
    UIManager UI;

    public float targetX = 0f;
    bool isGrounded = true;
    bool isGameOver = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        UI = FindObjectOfType<UIManager>();

        int level = PlayerPrefs.GetInt("Level", 0);

        if (level == 0)
        {
            forwardSpeed = 6f;
        }
        else if (level == 1)
        {
            forwardSpeed = 8f;
        }
        else if (level == 2)
        {
            forwardSpeed = 10f;
        }
    }

    void Update()
    {
        if (isGameOver)
        {
            return;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            targetX = laneDistance;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            targetX = -laneDistance;
        }
        else
        {
            targetX = 0f;
        }

        bool isInMiddleLane = Mathf.Abs(rb.position.x) < 0.1f;

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded && isInMiddleLane)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        if (isGameOver)
        {
            return;
        }

        Vector3 pos = rb.position;

        float currentSpeed;

        if (isGrounded)
        {
            currentSpeed = forwardSpeed;
        }
        else
        {
            currentSpeed = forwardSpeed * 0.8f;
        }

        pos.z += currentSpeed * Time.fixedDeltaTime;
        pos.x = Mathf.Lerp(pos.x, targetX, smoothSideSpeed * Time.fixedDeltaTime);

        
        rb.MovePosition(new Vector3(pos.x, rb.position.y, pos.z));
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Ground")
        {
            isGrounded = true;
        }

        if (collision.gameObject.tag=="Obstacle" && !isGameOver)
        {
            isGameOver = true;

            GameOver.SetActive(true);
            UI.FinalGameUpdation();
            Time.timeScale = 0f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Coin")
        {
            Destroy(other.gameObject);
        }
    }
    
}
