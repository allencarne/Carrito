using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.OnScreen;

public class PlayerTouchInput : MonoBehaviour
{
    [SerializeField] CustomPlayerInput customPlayerInput;

    private void Update()
    {
        if (SoccerManager.instance != null && SoccerManager.instance.blue1Instance != null)
        {
            if (customPlayerInput == null)
            {
                customPlayerInput = SoccerManager.instance.blue1Instance.GetComponent<CustomPlayerInput>();
            }
        }
    }

    /*
    public void OnSteerLeftDown()
    {
        if (customPlayerInput)
        {
            customPlayerInput.SteerInput += Vector2.left;
        }
    }

    public void OnSteerLeftUp()
    {
        if (customPlayerInput)
        {
            customPlayerInput.SteerInput = Vector2.zero;
        }
    }

    public void OnSteerRightDown()
    {
        if (customPlayerInput)
        {
            customPlayerInput.SteerInput += Vector2.right;
        }
    }

    public void OnSteerRightUp()
    {
        if (customPlayerInput)
        {
            customPlayerInput.SteerInput = Vector2.zero;
        }
    }

    public void OnAccelerateDown()
    {
        if (customPlayerInput)
        {
            customPlayerInput.IsAccelerating = true;
        }
    }

    public void OnAccelerateUp()
    {
        if (customPlayerInput)
        {
            customPlayerInput.IsAccelerating = false;
        }
    }

    public void OnBrakeDown()
    {
        if (customPlayerInput)
        {
            customPlayerInput.IsBraking = true;
        }
    }

    public void OnBrakeUp()
    {
        if (customPlayerInput)
        {
            customPlayerInput.IsBraking = false;
        }
    }
    */

    public void OnBoostDown()
    {
        if (customPlayerInput)
        {
            customPlayerInput.IsBoosting = true;
        }
    }

    public void OnBoostUp()
    {
        if (customPlayerInput)
        {
            customPlayerInput.IsBoosting = false;
        }
    }

    public void OnDriftDown()
    {
        if (customPlayerInput)
        {
            customPlayerInput.IsDrifting = true;
        }
    }

    public void OnDriftUp()
    {
        if (customPlayerInput)
        {
            customPlayerInput.IsDrifting = false;
        }
    }
}
