using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSO : ScriptableObject
{
    [Range(0f, 1f)]
    public float MusicVolume;
    [Range(0f, 1f)]
    public float SfxVolume;

}
