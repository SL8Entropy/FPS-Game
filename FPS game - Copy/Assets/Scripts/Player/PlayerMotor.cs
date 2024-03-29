using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 playerVelocity;
    public Vector3 dashVelocity;
    public bool isGrounded;
    public float dashSpeed = 1000f;
    public float speed = 5;
    public float Gravity = -9.8f;
    public float jumpHeight = 3f;
    public bool secJump = true;
    public bool dashStun = false;
    public float dashStunTime;
    public float dashTime = 0f;
    private int dashInvertibleX = 0;
    private int dashInvertibleY = 0;
    public Vector3 knockbackVelocity;
    public float stunTime;
    public GameObject persist;
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

        if (stunTime > 0)
        {
            stunTime -= Time.deltaTime;
            if (stunTime < 0)
            {
                stunTime = 0;
            }
        }
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



        
        Debug.Log(dashVelocity);
        controller.Move(transform.TransformDirection(dashVelocity) * Time.deltaTime);
        

        if (stunTime > 0)
        {
            if (playerVelocity.y > 0)
            {
                playerVelocity.y = 0;
            }
            playerVelocity.y += Gravity/2 * Time.deltaTime;
        }
        else
        {
            controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
            
            playerVelocity.y += Gravity * Time.deltaTime;
        }
        controller.Move(knockbackVelocity);
        if (knockbackVelocity != Vector3.zero)
        {
            for (int i = 0; i<3; i++)
            {
                float knockbackReduction = 10;
                if (isGrounded)
                    knockbackReduction = 5;

                
                if (knockbackVelocity[i] > 0)
                {
                    knockbackVelocity[i] -= knockbackReduction * Time.deltaTime;
                    if (knockbackVelocity[i] <= 0)
                    {
                        knockbackVelocity[i] = 0;
                    }
                }
                else if (knockbackVelocity[i] < 0)
                {
                    knockbackVelocity[i] += knockbackReduction * Time.deltaTime;
                    if (knockbackVelocity[i] >= 0)
                    {
                        knockbackVelocity[i] = 0;
                    }
                }

            }
        }

        if (dashVelocity != Vector3.zero)
        {
            for (int i = 0; i < 3; i++)
            {
                if (dashVelocity[i] > 0)
                {
                    dashVelocity[i] -= 100 * Time.deltaTime;
                    if (dashVelocity[i] <= 0)
                    {
                        dashVelocity[i] = 0;
                    }
                }
                else if (dashVelocity[i] < 0)
                {
                    dashVelocity[i] += 100 * Time.deltaTime;
                    if (dashVelocity[i] >= 0)
                    {
                        dashVelocity[i] = 0;
                    }
                }


            }
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
            dashVelocity.z = Mathf.Sqrt(Mathf.Abs(Input.y) * dashSpeed);
            dashVelocity.x = Mathf.Sqrt(Mathf.Abs(Input.x) * dashSpeed);
            if (Input.y < 0)
            {
                dashInvertibleY = -1;
                dashVelocity.z = dashVelocity.z * -1;
            }
            else if (Input.y > 0)
            {
                dashInvertibleY = 1;
            }
            else
            {
                dashInvertibleY = 0;
            }

            if (Input.x < 0)
            {
                dashInvertibleX = -1;
                dashVelocity.x = dashVelocity.x * -1;
            }
            else if (Input.x > 0)
            {
                dashInvertibleX = 1;
            }
            else
            {
                dashInvertibleX = 0;
            }


            dashStun = true;
            dashTime = 0f;
        }
    }
}
