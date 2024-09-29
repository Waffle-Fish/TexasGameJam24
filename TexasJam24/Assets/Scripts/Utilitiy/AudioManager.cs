using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    AudioSO audioSettings;

    [SerializeField]
    AudioSource jukebox;

    List<AudioSource> allSfxSources;

    private void Awake() {
        allSfxSources = GameObject.FindObjectsOfType<AudioSource>().ToList<AudioSource>();
        allSfxSources.Remove(jukebox);

        jukebox.volume = audioSettings.MusicVolume;
        
    }

    public void SetMusicVolume() {
        jukebox.volume = audioSettings.MusicVolume;
    }

    public void SetSfxVolume() {
        foreach (var audSor in allSfxSources)
        {
            audSor.volume = audioSettings.SfxVolume;
        }
    }

    public void UpdateMusicVolume(float vol) {
        vol = Mathf.Clamp(vol, 0f,1f);
        audioSettings.MusicVolume = vol;
    }

    public void UpdateSfxVolume(float vol) {
        vol = Mathf.Clamp(vol, 0f,1f);
        audioSettings.SfxVolume = vol;
    }
}
