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
        }
    }
}
