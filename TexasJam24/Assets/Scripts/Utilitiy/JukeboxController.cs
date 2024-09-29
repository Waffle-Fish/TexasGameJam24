using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class JukeboxController : MonoBehaviour
{
    [TitleGroup("Variables")]
    [SerializeField]
    [Tooltip("Delay to add when playing")]
    private float delay;

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
        audioSource.PlayDelayed(delay);
    }

    public void Pause() {
        audioSource.Pause();
    }

    public void Resume() {
        audioSource.UnPause();
    }

    public float GetAudioClipDuration() {
        return audioSource.clip.length;
    }

    public void Stop() {
        audioSource.Stop();
    }

    public void PlayOneShot(AudioClip ac) {
        audioSource.Stop();
        audioSource.PlayOneShot(ac);
    }

    public void Play() {
        audioSource.Stop();
        audioSource.Play();
    }
}
