using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeftStick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] CustomPlayerInput customPlayerInput;
    private Vector2 initialPosition;

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

    public void OnPointerDown(PointerEventData eventData)
    {
        initialPosition = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        float deltaY = eventData.position.y - initialPosition.y;

        if (deltaY > 0)
        {
            // If the stick is moving upwards, accelerate
            customPlayerInput.IsAccelerating = true;
            customPlayerInput.IsBraking = false;
        }
        else if (deltaY < 0)
        {
            // If the stick is moving downwards, brake
            customPlayerInput.IsAccelerating = false;
            customPlayerInput.IsBraking = true;
        }

        float deltaX = eventData.delta.x;

        // Only update the steering input if the stick has moved horizontally
        if (deltaX != 0)
        {
            // Create a new Vector2 for the stick movement
            Vector2 stickMovement = new Vector2(deltaX, 0);

            // Apply the dead zone
            stickMovement = ApplyDeadZone(stickMovement);

            // Check the direction of the stick movement and update the player's inputs accordingly
            if (stickMovement.x > 0)
            {
                // If the stick is moving to the right, steer right
                customPlayerInput.SteerInput = new Vector2(.5f, 0);
            }
            else if (stickMovement.x < 0)
            {
                // If the stick is moving to the left, steer left
                customPlayerInput.SteerInput = new Vector2(-.5f, 0);
            }
        }
        else
        {
            // If the stick has not moved horizontally, set the steering input to zero
            customPlayerInput.SteerInput = Vector2.zero;
        }
    }

    private Vector2 ApplyDeadZone(Vector2 input)
    {
        const float deadZoneSize = 0.6f; // Adjust this value to suit your needs

        if (input.magnitude < deadZoneSize)
        {
            // If the input vector is within the dead zone, return a zero vector
            return Vector2.zero;
        }
        else
        {
            // Otherwise, return the original input vector
            return input;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // If the stick is not moving, stop steering
        customPlayerInput.SteerInput = Vector2.zero;

        // If the stick is not moving, stop accelerating and braking
        customPlayerInput.IsAccelerating = false;
        customPlayerInput.IsBraking = false;
    }
}
