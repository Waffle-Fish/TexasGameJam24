using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class JukeboxController : MonoBehaviour
{
    [TitleGroup("Test Functions")]
    [ButtonGroup("Test Functions/Pause")]
    public void ButtonPause() { Pause(); }
    [ButtonGroup("Test Functions/Resume")]
    public void ButtonResume() { Resume(); }

    public static JukeboxController Instance { get; private set; }
    private AudioSource audioSource;

    private void Awake() {
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
        audioSource = GetComponent<AudioSource>();
    }

    private void Update() {
        // if (!audioSource.isPlaying) {

        // }
    }

    public void Pause() {
        audioSource.Pause();
    }

    public void Resume() {
        audioSource.UnPause();
    }
}
