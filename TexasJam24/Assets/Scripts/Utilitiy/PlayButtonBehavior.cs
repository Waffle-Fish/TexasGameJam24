using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;
using UnityEngine.UI;

public class PlayButtonBehavior : MonoBehaviour
{
    [SerializeField]
    private PlayableDirector pd;
    [SerializeField]
    private int buildIndex;
    private Button playButton;

    private void Awake() {
        playButton = GetComponent<Button>();
        playButton.onClick.AddListener(ProcessPlay);
    }

    private void ProcessPlay()
    {
        pd.gameObject.SetActive(true);
        StartCoroutine(DelayLoadScene());
    }

    private IEnumerator DelayLoadScene() {
        yield return new WaitForSeconds((float)pd.playableAsset.duration);
        SceneController.Instance.LoadScene(buildIndex);
    }
}
