using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CustomPlayerInput : MonoBehaviour
{
    public Vector2 SteerInput { get; private set; }
    public bool IsAccelerating { get; private set; }
    public bool IsBraking { get; private set; }
    public bool IsBoosting { get; private set; }
    public bool IsDrifting { get; private set; }

    public void OnSteer(InputAction.CallbackContext context)
    {
        SteerInput = context.ReadValue<Vector2>();

        if (context.canceled)
        {
            SteerInput = Vector2.zero;
        }
    }

    public void OnAccelerate(InputAction.CallbackContext context)
    {
        IsAccelerating = context.ReadValueAsButton();

        if (context.canceled)
        {
            IsAccelerating = false;
        }
    }

    public void OnBrake(InputAction.CallbackContext context)
    {
        IsBraking = context.ReadValueAsButton();

        if (context.canceled)
        {
            IsBraking = false;
        }
    }

    public void OnBoost(InputAction.CallbackContext context)
    {
        IsBoosting = context.ReadValueAsButton();

        if (context.canceled)
        {
            IsBoosting = false;
        }
    }

    public void OnDrift(InputAction.CallbackContext context)
    {
        IsDrifting = context.ReadValueAsButton();

        if (context.canceled)
        {
            IsDrifting = false;
        }
    }
}
