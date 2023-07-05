using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private BoxCollider2D collider;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    [SerializeField] private LayerMask jumpableGround;

    float dirX = 0f;
    float dirY = 0f;

    [SerializeField] private float jumpVelocity = 7f;
    [SerializeField] private float runSpeed = 7f;

    private enum MovementState { idle, running, jumping, falling };

    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        dirY = rb.velocity.y;

        rb.velocity = new Vector2(dirX * runSpeed, rb.velocity.y);


        Jump();

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        MovementState state = MovementState.idle;
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if(dirY > .1f)
        {
            state = MovementState.jumping;
        }
        else if (dirY < -.1f)
        {
            state = MovementState.falling;
        }

        animator.SetInteger("state", (int)state);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
