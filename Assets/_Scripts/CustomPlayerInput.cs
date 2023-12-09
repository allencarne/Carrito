using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CustomPlayerInput : MonoBehaviour
{
    public int playerID;

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
        steerAction.Enable();
        accelerateAction.Enable();
        brakeAction.Enable();
        boostAction.Enable();
        driftAction.Enable();
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

        if (playerID == 1)
        {
            steerAction = playerControls.Player.Steer1;
            steerAction.performed += OnSteer;
            steerAction.canceled += OnSteerCanceled;

            accelerateAction = playerControls.Player.Accelerate1;
            accelerateAction.started += OnAccelerate;
            accelerateAction.canceled += OnAccelerateCanceled;

            brakeAction = playerControls.Player.Break1;
            brakeAction.started += OnBrake;
            brakeAction.canceled += OnBrakeCanceled;

            boostAction = playerControls.Player.Boost1;
            boostAction.started += OnBoost;
            boostAction.canceled += OnBoostCanceled;

            driftAction = playerControls.Player.Drift1;
            driftAction.started += OnDrift;
            driftAction.canceled += OnDriftCanceled;
        }

        if (playerID == 2)
        {
            steerAction = playerControls.Player.Steer2;
            steerAction.performed += OnSteer;
            steerAction.canceled += OnSteerCanceled;

            accelerateAction = playerControls.Player.Accelerate2;
            accelerateAction.started += OnAccelerate;
            accelerateAction.canceled += OnAccelerateCanceled;

            brakeAction = playerControls.Player.Break2;
            brakeAction.started += OnBrake;
            brakeAction.canceled += OnBrakeCanceled;

            boostAction = playerControls.Player.Boost2;
            boostAction.started += OnBoost;
            boostAction.canceled += OnBoostCanceled;

            driftAction = playerControls.Player.Drift2;
            driftAction.started += OnDrift;
            driftAction.canceled += OnDriftCanceled;
        }
    }

    public void OnSteer(InputAction.CallbackContext context)
    {
        SteerInput = context.ReadValue<Vector2>();
    }

    public void OnSteerCanceled(InputAction.CallbackContext context)
    {
        SteerInput = Vector2.zero;
    }

    public void OnAccelerate(InputAction.CallbackContext context)
    {
        IsAccelerating = true;
    }

    public void OnAccelerateCanceled(InputAction.CallbackContext context)
    {
        IsAccelerating = false;
    }

    public void OnBrake(InputAction.CallbackContext context)
    {
        IsBraking = true;
    }

    public void OnBrakeCanceled(InputAction.CallbackContext context)
    {
        IsBraking = false;
    }

    public void OnBoost(InputAction.CallbackContext context)
    {
        IsBoosting = true;
    }

    public void OnBoostCanceled(InputAction.CallbackContext context)
    {
        IsBoosting = false;
    }

    public void OnDrift(InputAction.CallbackContext context)
    {
        IsDrifting = true;
    }

    public void OnDriftCanceled(InputAction.CallbackContext context)
    {
        IsDrifting = false;
    }
}
