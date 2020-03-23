using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControl : MonoBehaviour
{
    public GameManagerController _gameController;
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
        _gameController = GameManagerController.Instance;
        StartCoroutine(ResetButtons());
        
    }

    private IEnumerator ResetButtons()
    {
        if (_gameController.interagindo1 == true)
            {
                Debug.Log("start coouroutine");
                yield return new WaitForSeconds(100*Time.deltaTime);
                _gameController.interagindo1 = false;
                Debug.Log("end couroutine");

            }

            if (_gameController.interagindo2 == true)
            {
                Debug.Log("start coouroutine");
                yield return new WaitForSeconds(100*Time.deltaTime);
                _gameController.interagindo2 = false;
                Debug.Log("end couroutine");
            }
    }

    void Update()
    {
        if (current.tag == "Player1")
        {
            horizontalMove = Input.GetAxisRaw("Horizontal.P1") * runSpeed;

            if (Input.GetButtonDown("Jump.P1"))
            {
                jump = true;
            }

            if (Input.GetButton("Interactive.P1"))
            {
                _gameController.interagindo1 = true;
                Debug.Log("botão 1");
            }

        }

        if (current.tag == "Player2")
        {
            horizontalMove = Input.GetAxisRaw("Horizontal.P2") * runSpeed;

            if (Input.GetButtonDown("Jump.P2"))
            {
                jump = true;
            }

            if (Input.GetButton("Interactive.P2"))
            {
                _gameController.interagindo2 = true;
                Debug.Log("botão 2");
            }
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
        StartCoroutine(ResetButtons());
        //ResetButtonsFalse();
    }
    
}