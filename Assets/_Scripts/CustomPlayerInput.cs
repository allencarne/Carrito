using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CustomPlayerInput : MonoBehaviour
{
    PlayerControls playerControls;

    public InputAction steerAction;
    private InputAction accelerateAction;
    private InputAction brakeAction;
    private InputAction boostAction;
    private InputAction driftAction;

    public Vector2 SteerInput { get; private set; }
    public bool IsAccelerating { get; private set; }
    public bool IsBraking { get; private set; }
    public bool IsBoosting { get; private set; }
    public bool IsDrifting { get; private set; }

    private void OnEnable()
    {
        steerAction = playerControls.Player.Steer;
        steerAction.Enable();
        steerAction.performed += ctx => SteerInput = ctx.ReadValue<Vector2>();

        accelerateAction = playerControls.Player.Accelerate;
        accelerateAction.Enable();
        accelerateAction.started += ctx => IsAccelerating = true;
        accelerateAction.canceled += ctx => IsAccelerating = false;

        brakeAction = playerControls.Player.Break;
        brakeAction.Enable();
        brakeAction.started += ctx => IsBraking = true;
        brakeAction.canceled += ctx => IsBraking = false;

        boostAction = playerControls.Player.Boost;
        boostAction.Enable();
        boostAction.started += ctx => IsBoosting = true;
        boostAction.canceled += ctx => IsBoosting = false;

        driftAction = playerControls.Player.Drift;
        driftAction.Enable();
        driftAction.started += ctx => IsDrifting = true;
        driftAction.canceled += ctx => IsDrifting = false;
    }

    private void OnDisable()
    {
        steerAction.Disable();
        accelerateAction.Disable();
        brakeAction.Disable();
        boostAction.Disable();
        driftAction.Disable();
    }

    private void Awake()
    {
        playerControls = new PlayerControls();
    }
}
