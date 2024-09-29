using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class DelayBeatMapManager : MonoBehaviour
{
    [SerializeField]
    private float delay;
    BeatMapManager bmm;

    private float timer;
    private bool eot;

    private void Awake() {
        bmm = GetComponent<BeatMapManager>();
        bmm.enabled = delay == 0;
    }

    private void Start() {
        timer = delay;
        eot = false;
    }

    private void Update() {
        timer -= Time.deltaTime;
        if (timer <= 0 && !eot) {
            eot = true;
            ProcessEndOfTimer();
        }
    }

    private void ProcessEndOfTimer()
    {
        bmm.enabled = true;
        JukeboxController.Instance.Play();
        this.enabled = false;
    }
}
