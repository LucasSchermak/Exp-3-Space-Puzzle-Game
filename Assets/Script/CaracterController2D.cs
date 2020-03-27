using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CaracterController2D : MonoBehaviour
{

    [SerializeField] private float jumpForce = 400f;
    [Range(0, 1)] [SerializeField] private float crouchSpeed = .36f;
    [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;
    [SerializeField] private bool airControl = false;
    [SerializeField] private Collider2D crouchDisableCollider;
    public GameObject tutorial;

    private bool grounded;
    private bool facingRight = true;
    private Vector3 velocity = Vector3.zero;
    [SerializeField]private Rigidbody2D rb;
    [SerializeField] private Collision coll;


    private bool wasCrouching = false;

    private void Start()
    {
        tutorial.SetActive(false);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collision>();
    }

    private void FixedUpdate()
    {
        grounded = false || coll.onGround;
    }

    public void Move(float move, bool crouch, bool jump)
    {
        if (!crouch)
        {
            if (coll.cellingCheck)
            {
                crouch = true;
            }
        }

        if (grounded || airControl)
        {
            if (crouch)
            {
                if (!wasCrouching)
                {
                    wasCrouching = true;
                }

                move += crouchSpeed;
                if (crouchDisableCollider != null)
                    crouchDisableCollider.enabled = true;

            }
            else
            {
                if (crouchDisableCollider != null)
                    crouchDisableCollider.enabled = true;
                if (wasCrouching)
                {
                    wasCrouching = false;
                }
            }

            Vector3 targetVelocity = new Vector2(move * 10f, rb.velocity.y);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movementSmoothing);

            if (move > 0 && !facingRight)
            {
                Flip();
            }
            else if (move < 0 && facingRight)
            {
                Flip();
            }
        }

        if (grounded && jump)
        {
            grounded = false;
            rb.AddForce(new Vector2(0f, jumpForce));
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 localScale = transform.localScale;

        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
