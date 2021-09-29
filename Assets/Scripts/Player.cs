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
        //Movement input
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        //Apply movement value to Speed float for animation
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        //Jump input
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        Debug.Log(Mathf.Abs(rigidbody2D.velocity.y));
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
    }

    void FixedUpdate()
    {
        //Movement function
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        //Reset jump bool immediately
        jump = false;
    }
}
