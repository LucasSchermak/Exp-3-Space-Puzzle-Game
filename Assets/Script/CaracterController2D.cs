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
    private GameManagerController _gameController;
    public GameObject tutorial;

    private bool grounded;
    private bool interagindo1;
    private bool interagindo2;
    private bool facingRight = true;
    private Vector3 velocity = Vector3.zero;
    [SerializeField]private Rigidbody2D rb;
    [SerializeField] private Collision coll;

    [Header("Events")] [Space]
    public UnityEvent OnLandEvent;
    public UnityEvent OnInteractEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool>
    {
    }

    public BoolEvent OnCrouchEvent;
    private bool wasCrouching = false;

    private void Start()
    {
        tutorial.SetActive(false);
        _gameController = GameManagerController.Instance;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collision>();
        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();
        if (OnInteractEvent == null)
            OnInteractEvent = new UnityEvent();

        if (OnCrouchEvent == null)
            OnCrouchEvent = new BoolEvent();
    }

    void FixedUpdate()
    {
        interagindo1 = false;
        grounded = false;
        if (coll.onGround)
        {
            grounded = true;
        }

        if (!coll.onGround)
        {
            OnLandEvent.Invoke();

        }        
      
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
                    OnCrouchEvent.Invoke(true);
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
                    OnCrouchEvent.Invoke(false);
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

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.tag == "Button1")
        {
            tutorial.SetActive(true);
            _gameController.onButton1 = true;
        }

        if (other.gameObject.tag == "Button2")
        {
            tutorial.SetActive(true);
            _gameController.onButton2 = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        tutorial.SetActive(false);
        _gameController.onButton1 = false;
        _gameController.onButton2 = false;
    }
}
