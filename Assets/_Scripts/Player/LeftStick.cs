using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftStick : MonoBehaviour
{
    [SerializeField] Joystick joystick;
    [SerializeField] CustomPlayerInput customPlayerInput;

    private void Update()
    {
        if (SoccerManager.instance != null && SoccerManager.instance.blue1Instance != null)
        {
            if (customPlayerInput == null)
            {
                customPlayerInput = SoccerManager.instance.blue1Instance.GetComponent<CustomPlayerInput>();
            }

            // Create a Vector2 from the joystick's horizontal input
            Vector2 steerInput = new Vector2(joystick.Horizontal, 0f);

            // Assign the created Vector2 to SteerInput
            customPlayerInput.SteerInput = steerInput;

            // Create a Vector2 from the joystick's vertical input for acceleration and braking
            Vector2 accelerateInput = new Vector2(0f, joystick.Vertical);

            // Assign the created Vector2 to Acceleration and Braking
            customPlayerInput.Acceleration = Mathf.Clamp01(accelerateInput.y); // Clamping between 0 and 1
            customPlayerInput.Brake = Mathf.Clamp01(-accelerateInput.y); // Clamping between 0 and 1

            // Optional: You can set IsAccelerating and IsBraking based on the Acceleration and Braking values
            customPlayerInput.IsAccelerating = customPlayerInput.Acceleration > 0;
            customPlayerInput.IsBraking = customPlayerInput.Brake > 0;
        }
    }
}
