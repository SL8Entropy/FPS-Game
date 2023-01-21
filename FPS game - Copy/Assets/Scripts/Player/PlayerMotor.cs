using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private Vector3 dashVelocity;
    public bool isGrounded;
    public bool Dashing;
    public float dashSpeed = 500f;
    public float speed = 5;
    public float Gravity = -9.8f;
    public float jumpHeight = 3f;
    public bool secJump = true;
    public bool dashStun = false;
    public float dashStunTime = 2f;
    public float dashTime = 0f;

    private InputManager inputmanager;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Awake()
    {
        inputmanager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
        if (isGrounded)
        {
            secJump = true;
        }
        if (dashStun)
        {
            dashTime += Time.deltaTime;
            if (dashTime >= dashStunTime)
            {
                dashStun = false;
            }

        }
    }
    //recieves inputs from our InputManager.cs and apply them to our character controller.
    public void ProcessMove(Vector2 Input)
    {
        Vector3 moveDirection = Vector3.zero;
        
        moveDirection.x = Input.x;
        moveDirection.z = Input.y;
        speed = 5;



        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        
        controller.Move(transform.TransformDirection(dashVelocity) * Time.deltaTime);

        

        playerVelocity.y += Gravity * Time.deltaTime;
        
        dashVelocity.z -= 50 * Time.deltaTime;

        

        if (dashVelocity.z <= 0)
        {
            dashVelocity.z = 0;
        }
        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;
        controller.Move(playerVelocity * Time.deltaTime);

        Debug.Log(playerVelocity.y);
    }
    public void Jump()
    {
        if (isGrounded || secJump)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * Gravity);
            if (isGrounded == false)
            {
                secJump = false;
            }
        }
    }
    public void Dash(Vector2 Input)
    { 
        if (dashStun == false)
        {
            dashVelocity.z = Mathf.Sqrt(Input.y * dashSpeed);
            dashTime = 0f;
            dashStun = true;
        }
    }
}
