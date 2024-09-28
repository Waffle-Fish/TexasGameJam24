using System;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "BeatMap", menuName = "Custom/BeatMaps", order = 1)]
public class BeatMapSO : ScriptableObject
{
    [Serializable]
    public struct Beat {
        [FoldoutGroup("$Time")]
        public GameObject beatObject;

        [TitleGroup("$Time/Map")]
        [HorizontalGroup("$Time/Map/Split")]
        [VerticalGroup("$Time/Map/Split/Left")]
        [BoxGroup("$Time/Map/Split/Left/Timing")]
        [HorizontalGroup("$Time/Map/Split/Left/Timing/Split")]
        [VerticalGroup("$Time/Map/Split/Left/Timing/Split/Left")]
        [Range(0, 4)]
        public int min;
        
        [VerticalGroup("$Time/Map/Split/Left/Timing/Split/Right")]
        [Range(0,59)]
        public int sec;

        [VerticalGroup("$Time/Map/Split/Right")]
        [FoldoutGroup("$Time/Map/Split/Right/Tracks", GroupName = "Beats on Track")]
        public bool Track1;
        [FoldoutGroup("$Time/Map/Split/Right/Tracks")]
        public bool Track2;
        [FoldoutGroup("$Time/Map/Split/Right/Tracks")]
        public bool Track3;
        [FoldoutGroup("$Time/Map/Split/Right/Tracks")]
        public bool Track4;

        public string Time { get { return $"{min.ToString("D1")} : {sec.ToString("D2")}";}}
        public readonly int GetTimeInSeconds { get { return min * 60 + sec;}}
    }

    [TitleGroup("Dev Controls")]
    public int numberOfBeats = 0;
    public GameObject beatGameObject;
    
    public string RandomXBeats { get { return "Randomize " + numberOfBeats + " beats";}}
    [ButtonGroup("Dev Controls/Clear BeatMap")]
    private void ClearBeatMap() {
        beatMap.Clear();
    }

    [ButtonGroup("Dev Controls/$RandomXBeats")]
    private void RandomizeBeatMap() {
        beatMap.Clear();
        for (int i = 0; i < numberOfBeats; i++)
        {
            beatMap.Add(new Beat());
        }

        for (int i = 0; i < numberOfBeats; i++)
        {
            beatMap[i] = RandomizeBeat();
        }

        beatMap.Sort(delegate(Beat a, Beat b) {
            if (a.min * 60 + a.sec > b.min * 60 + b.sec) {
                return 1;
            } else {
                return -1;
            }
        });
    }

    [TitleGroup("BeatMap")]
    public List<Beat> beatMap;

    private Beat RandomizeBeat() {
        Beat b = new()
        {
            beatObject = beatGameObject,

            min = UnityEngine.Random.Range(0, 4),
            sec = UnityEngine.Random.Range(0, 60),

            Track1 = UnityEngine.Random.value < 0.5f,
            Track2 = UnityEngine.Random.value < 0.5f,
            Track3 = UnityEngine.Random.value < 0.5f,
            Track4 = UnityEngine.Random.value < 0.5f
        };

        // Check if all tracks have a beat on them
        if (b.Track1 && b.Track2 && b.Track3 && b.Track4) {
            switch (UnityEngine.Random.Range(0, 4)) {
                case 0:
                    b.Track1 = false;
                    break;
                case 1:
                    b.Track2 = false;
                    break;
                case 2:
                    b.Track3 = false;
                    break;
                case 3:
                    b.Track4 = false;
                    break;
                default:
                    Debug.LogError("This shouldn't happen");
                    break;
            }
        }
        return b;
    }
}
