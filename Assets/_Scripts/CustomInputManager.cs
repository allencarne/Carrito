using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CustomInputManager : MonoBehaviour
{
    private List<PlayerInput> players = new List<PlayerInput>();

    private void OnEnable()
    {
        PlayerInputManager.instance.onPlayerJoined += OnPlayerJoined;
        PlayerInputManager.instance.onPlayerLeft += OnPlayerLeft;
    }

    private void OnDisable()
    {
        PlayerInputManager.instance.onPlayerJoined -= OnPlayerJoined;
        PlayerInputManager.instance.onPlayerLeft -= OnPlayerLeft;
    }

    private void OnPlayerJoined(PlayerInput playerInput)
    {
        players.Add(playerInput);
        Debug.Log($"Player {players.Count} joined!");
    }

    private void OnPlayerLeft(PlayerInput playerInput)
    {
        players.Remove(playerInput);
        Debug.Log($"Player left. Remaining players: {players.Count}");
    }

    private void Update()
    {
        // Process input for each player
        foreach (var player in players)
        {
            // Get input actions from the player
            //var movement = player.actions["Move"].ReadValue<Vector2>();
            //var jump = player.actions["Jump"].triggered;

            // Add your player control logic here
            // For example, move the player based on input
            // player.transform.Translate(new Vector3(movement.x, 0, movement.y) * Time.deltaTime);

            // Add more logic based on your game's requirements
        }
    }
}
