using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]private GameManagerController gameController;
    [SerializeField]private PlayerController controller;
    [SerializeField]private GameObject current;

    [SerializeField]private float runSpeed = 40f;
    [SerializeField]private bool jump = false;
    [SerializeField]private float horizontalMove = 0f;

    
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
    }

    private void FixedUpdate()
    {
        controller.Move(move: horizontalMove * Time.fixedDeltaTime, crouch: false, jump: jump);
        jump = false;
    }
    
}