using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField]
    List<Transform> playerTrackTransform;

    PlayerInputs playerInput;

    private void OnEnable() {
        playerInput.SwitchTrack.Enable();
    }

    private void OnDisable() {
        playerInput.SwitchTrack.Disable();
    }
    
    private void Awake() {
        playerInput = new();
        playerInput.SwitchTrack.Track1.performed += SwitchTrack(1);
        playerInput.SwitchTrack.Track2.performed += SwitchTrack(2);
        playerInput.SwitchTrack.Track3.performed += SwitchTrack(3);
        playerInput.SwitchTrack.Track4.performed += SwitchTrack(4);
    }

    private Action<InputAction.CallbackContext> SwitchTrack(int v)
    {
        return x => {transform.position = playerTrackTransform[v-1].position;};
    }
}
