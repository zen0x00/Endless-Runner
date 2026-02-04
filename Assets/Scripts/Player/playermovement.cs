using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
  public float forwardSpeed = 6f;
  public float laneDistance = 2f;
  public float smoothSideSpeed = 6f;
  public float jumpForce = 7f;
  public float gravityMultiplier = 2f;

  private float targetX = 0f;

  private Rigidbody rb;
  private bool isGrounded = true;

  void Start()
  {
    rb = GetComponent<Rigidbody>();
  }

  void Update()
  {
    transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
    if (Input.GetKey(KeyCode.D))
    {
      targetX = laneDistance;
    }
    else if (Input.GetKey(KeyCode.A))
    {
      targetX = -laneDistance;
    }
    else
    {
      targetX = 0f;
    }
    Vector3 newPos = transform.position;
    newPos.x = Mathf.Lerp(transform.position.x, targetX, smoothSideSpeed * Time.deltaTime);
    transform.position = newPos;

    // ✅ Jump when pressing E
    if (Input.GetKeyDown(KeyCode.E) && isGrounded)
    {
      Jump();
    }
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
}



