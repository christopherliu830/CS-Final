using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerLobbyController : MonoBehaviour
{

    private Rigidbody2D rb;

    private bool jumped;
    private int canJump;
    public float jumpForce;
    public float hoverForce;
    private float distToGround;
    public LayerMask layermask;

    private int points;
    public int slot;
    public string color;

    private Animator animator;

    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        distToGround = GetComponent<Collider2D>().bounds.extents.y;

    }

    // Update is called once per frame
    void FixedUpdate()
    {


        if (jumped && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetTrigger("jumpAnimTrigger");
            canJump = 20;
        }
        if (jumped && canJump >= 0)
        {
            rb.velocity += new Vector2(0, hoverForce);
        }

        if (!IsGrounded())
        {
            canJump--;
        }


    }

    void Update()
    {
        animator.SetFloat("moveSpeed", Math.Abs(rb.velocity.x));
        animator.SetBool("moving", rb.velocity.magnitude >= 0.0001);
        animator.SetBool("isGrounded", IsGrounded());
        animator.SetFloat("yVelocity", rb.velocity.y);

        jumped = Input.GetKey(PlayerData.playerKeys[slot]);

    }

    Boolean IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, Vector3.down, distToGround + 0.1f, layermask);
        return raycastHit.collider != null;
    }
}
