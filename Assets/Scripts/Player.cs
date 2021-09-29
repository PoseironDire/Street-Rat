using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public Rigidbody2D rigidbody2D;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    private int onLandFix;

    Vector3 spawnPoint = new Vector3();
    public float falloff = -10f;

    void Start()
    {
        SetSpawn();
    }

    void Update()
    {
        //Movement
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Mathf.Abs(rigidbody2D.velocity.y) > 1f)
        {
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }

        //Respawn
        if (transform.position.y <= falloff)
        {
            Respawn();
        }
    }

    // public void OnLanding()
    // {
    //     animator.SetBool("IsJumping", false);
    // }

    public void SetSpawn()
    {
        spawnPoint = new Vector3(transform.position.x, transform.position.y, 0);
    }

    public void Respawn()
    {
        transform.position = spawnPoint;
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }
}
