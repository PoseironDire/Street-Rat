using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public Joystick joystick;
    public Rigidbody2D rigidbody2D;

    public float runSpeed = 40f;
    public bool useJoystick = false;
    float horizontalMove = 0f;
    bool jump = false;

    Vector3 spawnPoint = new Vector3();
    public float falloff = -10f;

    void Start()
    {
        SetSpawn();
    }

    void Update()
    {
        //Movement input
        if (useJoystick)
        {
             if (joystick.Horizontal >= .1f)
            {
                horizontalMove = runSpeed;
            }
            else if (joystick.Horizontal <= -.1f)
            {
                horizontalMove = -runSpeed;
            }
            else
            {
                horizontalMove = 0f;
            }
        }
        else   
        { 
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        }

        float verticalMove = joystick.Vertical;

        //Apply movement value to Speed float for animation
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        //Jump input
        if (verticalMove >= .4f || Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        //Jump Animation
        if (Mathf.Abs(rigidbody2D.velocity.y) > 2f)
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

    //Sets the Player's Spawn Coordinates
    public void SetSpawn()
    {
        spawnPoint = new Vector3(transform.position.x, transform.position.y, 0);
    }

    //Respawns the Player at Spawn Coordinates
    public void Respawn()
    {
        transform.position = spawnPoint;

        //Respawn Sound
        FindObjectOfType<AudioManager>().Play("PlayerRespawn");
    }

    void FixedUpdate()
    {
        //Movement function
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        //Reset jump bool immediately
        jump = false;
    }
}
