using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    // [SerializeField]
    private int maxHealth;
    [SerializeField]
    List<GameObject> heartImages;

    [Header("Death")]
    [SerializeField]
    GameObject deathScreen;

    [SerializeField]
    AudioClip deathMusic;

    private int currrentHealth;
    private CircleCollider2D circleCollider2D;
    private void Awake() {
        circleCollider2D = GetComponent<CircleCollider2D>();
    }

    private void Start() {
        maxHealth = 3;
        currrentHealth = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("EnemyAttack")) {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        heartImages[math.max(0, currrentHealth-1)].SetActive(false);
        currrentHealth -= 1;
        if (currrentHealth <= 0) {
            ProcessDeath();
        }
    }

    private void ProcessDeath()
    {
        // Play Death Animation
        GetComponent<PlayerControls>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<PlayableDirector>().Play();


        // Reveal Death Screen
        deathScreen.SetActive(true);
        JukeboxController.Instance.PlayOneShot(deathMusic);
    }
}
