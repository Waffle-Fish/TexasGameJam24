using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class WinManager : MonoBehaviour
{
    [SerializeField]
    AudioClip winMusic;

    float levelDuration;
    float currentTimer;

    PlayableDirector pd;
    AudioSource jukebox;

    bool proccessingWin = false;

    private void Awake() {
        pd = GetComponent<PlayableDirector>();
    }

    private void Start() {
        levelDuration = JukeboxController.Instance.GetAudioClipDuration();
        currentTimer = 0;
        jukebox = JukeboxController.Instance.GetComponent<AudioSource>();
    }

    private void Update() {
        currentTimer += Time.deltaTime;
        if (!proccessingWin && currentTimer >= levelDuration) {
            proccessingWin = true;
            ProcessWin();
        }
    }

    private void ProcessWin()
    {
        PauseManager.Instance.Pause();
        jukebox.Stop();
        jukebox.PlayOneShot(winMusic);
        pd.Play();
    }
}
