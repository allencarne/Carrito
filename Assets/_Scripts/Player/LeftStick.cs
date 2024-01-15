using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.OnScreen;

public class LeftStick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] CustomPlayerInput customPlayerInput;
    //[SerializeField] OnScreenStick stick;
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
        }
        else if (deltaY < 0)
        {
            // If the stick is moving downwards, brake
            customPlayerInput.IsBraking = true;
        }

        float deltaX = eventData.delta.x;

        if (deltaX > 0)
        {
            // If the stick is moving to the right, steer right
            customPlayerInput.SteerInput = Vector2.right;
        }
        else if (deltaX < 0)
        {
            // If the stick is moving to the left, steer left
            customPlayerInput.SteerInput = Vector2.left;
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
