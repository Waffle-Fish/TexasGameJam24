using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 0;

    private float currrentHealth;
    private CircleCollider2D circleCollider2D;

    private void Awake() {
        circleCollider2D = GetComponent<CircleCollider2D>();
    }

    private void Start() {
        currrentHealth = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("EnemyAttack")) {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        currrentHealth -= 1;
        if (currrentHealth <= 0) {
            ProcessDeath();
        }
    }

    private void ProcessDeath()
    {
        Debug.Log("Player has died!");
    }
}
