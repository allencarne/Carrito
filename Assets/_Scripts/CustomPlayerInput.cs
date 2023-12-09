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

    public InputAction steerAction2;
    private InputAction accelerateAction2;
    private InputAction brakeAction2;
    private InputAction boostAction2;
    private InputAction driftAction2;

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

        steerAction2.Enable();
        accelerateAction2.Enable();
        brakeAction2.Enable();
        boostAction2.Enable();
        driftAction2.Enable();
    }

    private void OnDisable()
    {
        steerAction.Disable();
        accelerateAction.Disable();
        brakeAction.Disable();
        boostAction.Disable();
        driftAction.Disable();

        steerAction2.Disable();
        accelerateAction2.Disable();
        brakeAction2.Disable();
        boostAction2.Disable();
        driftAction2.Disable();
    }

    private void Awake()
    {
        playerControls = new PlayerControls();

        if (playerID == 1)
        {
            steerAction = playerControls.Player.Steer;
            steerAction.performed += OnSteer;
            steerAction.canceled += OnSteerCanceled;

            accelerateAction = playerControls.Player.Accelerate;
            accelerateAction.started += OnAccelerate;
            accelerateAction.canceled += OnAccelerateCanceled;

            brakeAction = playerControls.Player.Break;
            brakeAction.started += OnBrake;
            brakeAction.canceled += OnBrakeCanceled;

            boostAction = playerControls.Player.Boost;
            boostAction.started += OnBoost;
            boostAction.canceled += OnBoostCanceled;

            driftAction = playerControls.Player.Drift;
            driftAction.started += OnDrift;
            driftAction.canceled += OnDriftCanceled;
        }

        if (playerID == 2)
        {
            steerAction2 = playerControls.Player.Steer;
            steerAction2.performed += OnSteer;
            steerAction2.canceled += OnSteerCanceled;

            accelerateAction2 = playerControls.Player.Accelerate;
            accelerateAction2.started += OnAccelerate;
            accelerateAction2.canceled += OnAccelerateCanceled;

            brakeAction2 = playerControls.Player.Break;
            brakeAction2.started += OnBrake;
            brakeAction2.canceled += OnBrakeCanceled;

            boostAction2 = playerControls.Player.Boost;
            boostAction2.started += OnBoost;
            boostAction2.canceled += OnBoostCanceled;

            driftAction2 = playerControls.Player.Drift;
            driftAction2.started += OnDrift;
            driftAction2.canceled += OnDriftCanceled;
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
