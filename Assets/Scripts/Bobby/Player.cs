using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;

    Rigidbody rb;

    private bool isGrounded = true;

    public float jumpForce = 6f;

    public float laneDistance = 3f;
    public float laneChangeSpeed = 10f;
    public int currentLane = 0;

    void Start()
    {
        rb  = GetComponent<Rigidbody>();
    }
    void Update()
    {
       
       

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            currentLane--;

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            currentLane++;

        currentLane = Mathf.Clamp(currentLane, -1, 1);

        if ((Input.GetKeyDown(KeyCode.Space)&&isGrounded)||Input.GetKeyDown(KeyCode.UpArrow))
            Jump();
    }


      void FixedUpdate()
    {
       // Forward movement
        Vector3 move = rb.position + Vector3.forward * speed * Time.fixedDeltaTime;

        // Lane movement
        float targetX = currentLane * laneDistance;
        move.x = Mathf.Lerp(rb.position.x, targetX, laneChangeSpeed * Time.fixedDeltaTime);

        rb.MovePosition(move);
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
        }
    }

}
