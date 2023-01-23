using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public PlayerInput playerInput;
    public PlayerInput.OnFootActions onFoot;

    private PlayerMotor motor;
    private PlayerLook look;
    // Awake is called before the first frame update

    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        onFoot.Jump.performed += ctx => motor.Jump();

        onFoot.Dash.performed += ctx => motor.Dash(onFoot.Movement.ReadValue<Vector2>());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //tell the playermotor to move using value from movement action
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
        

    }
    void LateUpdate()
    {
        //look function
        if (motor.dashVelocity == Vector3.zero)
        {
            look.ProcessLook(onFoot.Look.ReadValue<Vector2>());

        }



    }
    private void OnEnable()
    {
        onFoot.Enable();
    }
    private void OnDisable()
    {
        onFoot.Disable();
    }
}
