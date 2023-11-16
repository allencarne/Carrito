using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    PlayerControls playerControls;

    public InputAction _Steer;
    private InputAction _Accelerate;
    private InputAction _Break;
    private InputAction _Boost;
    private InputAction _Drift;

    private Vector2 steerInput;
    private bool isAccelerating = false;
    private bool isBreaking = false;
    private bool isBoosting = false;
    private bool isDrifting = false;

    public Vector2 SteerInput => steerInput;
    public bool IsAccelerating => isAccelerating;
    public bool IsBreaking => isBreaking;
    public bool IsBoosting => isBoosting;
    public bool IsDrifting => isDrifting;

    private void OnEnable()
    {
        _Steer = playerControls.Player.Steer;
        _Steer.Enable();
        _Steer.performed += ctx => steerInput = ctx.ReadValue<Vector2>();

        _Accelerate = playerControls.Player.Accelerate;
        _Accelerate.Enable();
        _Accelerate.started += ctx => isAccelerating = true;
        _Accelerate.canceled += ctx => isAccelerating = false;

        _Break = playerControls.Player.Break;
        _Break.Enable();
        _Break.started += ctx => isBreaking = true;
        _Break.canceled += ctx => isBreaking = false;

        _Boost = playerControls.Player.Boost;
        _Boost.Enable();
        _Boost.started += ctx => isBoosting = true;
        _Boost.canceled += ctx => isBoosting = false;

        _Drift = playerControls.Player.Drift;
        _Drift.Enable();
        _Drift.started += ctx => isDrifting = true;
        _Drift.canceled += ctx => isDrifting = false;
    }

    private void OnDisable()
    {
        _Steer.Disable();
        _Accelerate.Disable();
        _Break.Disable();
        _Boost.Disable();
        _Drift.Disable();
    }

    private void Awake()
    {
        playerControls = new PlayerControls();
    }
}
