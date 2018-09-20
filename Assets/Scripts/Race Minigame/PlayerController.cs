using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour {

    protected Rigidbody2D rb;
    public LayerMask layermask;
    protected KeyCode actionKey;

    private float distToGround;

    protected int points { get; set; }
    protected int rank { get; set; }
    public int slot; 
    public string color; 

    protected Animator animator;
    protected SpriteRenderer sprite;


	// Use this for initialization
	protected virtual void Awake() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        distToGround = GetComponentInChildren<Collider2D>().bounds.extents.y;

        this.enabled = false;
	}
    
    protected virtual void Start()
    {
        actionKey = PlayerData.playerKeys[slot];
    }

    protected virtual void OnEnable()
    { }

    protected virtual void Update()
    {
        animator.SetFloat("moveSpeed", Math.Abs(rb.velocity.x));
        animator.SetBool("moving", rb.velocity.magnitude >= 0.0001);
        animator.SetBool("isGrounded", IsGrounded());
        animator.SetFloat("yVelocity", rb.velocity.y);

        if (rb.velocity.x < 0) sprite.flipX = true;
        if (rb.velocity.x > 0) sprite.flipX = false;
    }

    protected Boolean IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, Vector3.down, distToGround + 0.1f, layermask);
        return raycastHit.collider != null;
    }
    
    public int GetPoints()
    { return points; }
    public string GetColor()
    { return color; }

    public int GetSlot()
    { return slot;  }

    public void SetRank(int newRank)
    { rank = newRank; }

    public int GetRank()
    { return rank; }

    public KeyCode GetActionKey()
    { return actionKey; }


}
