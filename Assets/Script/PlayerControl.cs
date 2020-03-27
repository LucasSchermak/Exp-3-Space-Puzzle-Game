using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class PlayerControl : MonoBehaviour
{
    public GameManagerController gameController;
    public CaracterController2D controller;
    public GameObject current;

    public float runSpeed = 40f;
    private bool jump = false;
    //private bool interagindo1 = false;
    //private bool interagindo2 = false;
    private bool crouch = false;
    private float horizontalMove = 0f;

    
    void Start()
    {
        gameController = GameManagerController.instance;
    }
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal.P1") * runSpeed;

        if (Input.GetButtonDown("Jump.P1"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(move: horizontalMove * Time.fixedDeltaTime, crouch: false, jump: jump);
        jump = false;
    }
    
}