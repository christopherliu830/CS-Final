using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Race_PlayerController : PlayerController{

    private CameraController camc;
    private float moveX;
    public float accSpeed;
    public float moveSpeed;
    public float moveSpeedDecay;

    private bool jumped;
    private int canJump;
    public float jumpForce;
    public float hoverForce;

    private bool boosting;

	// Update is called once per frame
    protected override void Awake()
    {
        base.Awake();
        camc = Camera.main.GetComponent<CameraController>();
    }
	void FixedUpdate () {

        rb.velocity += new Vector2(accSpeed * moveX, 0);
        if (Math.Abs(rb.velocity.x) >= moveSpeed) rb.velocity = new Vector2(Math.Sign(rb.velocity.x) * moveSpeed, rb.velocity.y);
        if (moveX == 0) rb.velocity = new Vector2(rb.velocity.x / (1 + moveSpeedDecay), rb.velocity.y);


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

        if (!boosting) moveSpeed = camc.GetSpeed() - 0.01f;

	}

    protected override void OnEnable()
    {
        base.OnEnable();
        moveX = 1;
    }

    protected override void Update()
    {
        base.Update();
        jumped = Input.GetKey(PlayerData.playerKeys[slot]);
    }

    public void Boost(float speed, float duration)
    {
        moveSpeed = speed;
        boosting = true;
        Invoke("ResetBoost", duration);
    }

    void ResetBoost()
    {
        boosting = false;
    }

}
