using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playermovement : MonoBehaviour
{
  LevelManger levelManger;
  public float forwardSpeed = 6f;
  public float laneDistance = 2f;
  public float smoothSideSpeed = 6f;
  public float jumpForce = 7f;
  public float gravityMultiplier = 2f;
  public GameObject GameOver;
  UIManager UI;
  
  

  public float targetX = 0f;

  private Rigidbody rb;
  bool isGrounded = true;

  void Start()
  {
    rb = GetComponent<Rigidbody>();
   
    UI = FindObjectOfType<UIManager>();
    
    int level= PlayerPrefs.GetInt("Level",0);
    if (level == 0)
    {
      forwardSpeed =6f;
    }
    if (level == 1)
    {
      forwardSpeed =8f;
    }
    if (level == 2)
    {
      forwardSpeed =10f;
    }
  }

  void Update()
  {
    if (isGrounded){
      transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
    }
    else
    {
      transform.Translate(Vector3.forward * forwardSpeed* 0.7f * Time.deltaTime);
      
    }
    if (Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))
    {
      targetX = laneDistance;
    }
    else if (Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow))
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
    if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
    {
      Jump();
    }
  }

  void Jump()
  {
    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    isGrounded = false;
  }

   private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
          isGrounded = true;
        }
        if (collision.gameObject.tag == "Obstacle")
        {
            GameOver.SetActive(true);
            
            UI.FinalGameUpdation();
            Time.timeScale=0f;
            Debug.Log("Collided");
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






