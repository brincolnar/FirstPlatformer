using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public Animator animator;
  public CharacterController2D controller;
  float horizontalMove;
  public float runningSpeed = 40f;

  bool jump = false;
  bool crouch = false;

  // Update is called once per frame
  void Update()
  {
    horizontalMove = Input.GetAxisRaw("Horizontal") * runningSpeed;
    animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

    if (Input.GetButtonDown("Jump"))
    {
      animator.SetBool("isJumping", true);
      jump = true;
    }

    if (Input.GetButtonDown("Crouch"))
    {
      crouch = true;
    }
    else if (Input.GetButtonUp("Crouch"))
    {
      crouch = false;
    }
  }

  void FixedUpdate()
  {
    controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
    jump = false;
  }

  public void OnLanding()
  {
    animator.SetBool("isJumping", false);
  }

  public void OnCrouching(bool isCrouching)
  {
    animator.SetBool("isCrouching", isCrouching);
  }
}
