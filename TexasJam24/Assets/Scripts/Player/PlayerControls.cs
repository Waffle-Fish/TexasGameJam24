using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField]
    List<Transform> playerTrackTransform;

    [SerializeField]
    List<Sprite> playerSprites;

    PlayerInputs playerInput;
    SpriteRenderer playerSpriteRenderer;

    private void OnEnable() {
        playerInput.SwitchTrack.Enable();
    }

    private void OnDisable() {
        playerInput.SwitchTrack.Disable();
    }
    
    private void Awake() {
        playerInput = new();
        // playerSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        playerInput.SwitchTrack.Track1.performed += SwitchTrack(1);
        playerInput.SwitchTrack.Track2.performed += SwitchTrack(2);
        playerInput.SwitchTrack.Track3.performed += SwitchTrack(3);
        playerInput.SwitchTrack.Track4.performed += SwitchTrack(4);
    }

    private Action<InputAction.CallbackContext> SwitchTrack(int v)
    {
        // playerSpriteRenderer.sprite = playerSprites[v-1];
        return x => {transform.position = playerTrackTransform[v-1].position;};
    }
}
