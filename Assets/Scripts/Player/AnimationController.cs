using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
  private Animator animator;
  int isRunningHash;

  int jumpHash;
  void Start()
  {
    animator = GetComponent<Animator>();
    isRunningHash = Animator.StringToHash("isRunning");
    jumpHash = Animator.StringToHash("jump");
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      animator.SetTrigger("jump");
    }
  }
}
