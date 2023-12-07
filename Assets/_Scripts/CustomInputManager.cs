using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CustomInputManager : MonoBehaviour
{
    [SerializeField] PlayerInputManager playerInputManager;

    private List<PlayerInput> players = new List<PlayerInput>();

    private void OnEnable()
    {
        playerInputManager.onPlayerJoined += OnPlayerJoined;
        playerInputManager.onPlayerLeft += OnPlayerLeft;
    }

    private void OnDisable()
    {
        playerInputManager.onPlayerJoined -= OnPlayerJoined;
        playerInputManager.onPlayerLeft -= OnPlayerLeft;
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
}
