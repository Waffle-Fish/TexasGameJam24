using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatMapManager : MonoBehaviour
{
    [SerializeField]
    List<Transform> trackTransform;

    [SerializeField]
    BeatMapSO beatMapSO;

    [SerializeField]
    [Tooltip("Increase or decrease delay to when the beats spawn")]
    private float spawnOffset;

    ObjectPooler objPool;

    float currentTimer;
    int latestBeatMapInd = 0;

    private void Awake() {
        objPool = GetComponent<ObjectPooler>();
    }

    private void Start() {
        currentTimer = 0;
    }

    private void Update() {
        currentTimer += Time.deltaTime;

        ProcessBeatmap();
    }

    private void ProcessBeatmap()
    {        
        var beat = beatMapSO.beatMap[latestBeatMapInd];
        if (beat.GetTimeInSeconds + spawnOffset <= currentTimer) {
            if (beat.Track1) {
                GameObject g = objPool.GetPooledObject();
                g.GetComponent<SpellBehavior>().SetMoveForce(beat.speed);
                g.SetActive(true);
                g.transform.position = trackTransform[0].position;
            }
            if (beat.Track2) {
                GameObject g = objPool.GetPooledObject();
                g.GetComponent<SpellBehavior>().SetMoveForce(beat.speed);
                g.SetActive(true);
                g.transform.position = trackTransform[1].position;
            }
            if (beat.Track3) {
                GameObject g = objPool.GetPooledObject();
                g.GetComponent<SpellBehavior>().SetMoveForce(beat.speed);
                g.SetActive(true);
                g.transform.position = trackTransform[2].position;
            }
            if (beat.Track4) {
                GameObject g = objPool.GetPooledObject();
                g.GetComponent<SpellBehavior>().SetMoveForce(beat.speed);
                g.SetActive(true);
                g.transform.position = trackTransform[3].position;
            }
            latestBeatMapInd++;
        }
    }
}
