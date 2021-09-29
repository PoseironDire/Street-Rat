using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    private int onLandFix;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
            onLandFix = 0;
        }
        onLandFix++;
    }

    public void OnLanding()
    {
        // if (onLandFix >= 4)
        // {
        //     onLandFix = 0;
        animator.SetBool("IsJumping", false);
        // }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }
}
