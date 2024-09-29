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

    public static JukeboxController JukeboxControllerInstance;
    private AudioSource audioSource;

    private void Awake() {
        JukeboxControllerInstance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void Pause() {
        audioSource.Pause();
    }

    public void Resume() {
        audioSource.UnPause();
    }
}
