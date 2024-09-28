using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBehavior : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 1f;
    Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() {
        rb.AddForce(moveForce * -transform.right, ForceMode2D.Impulse);
    }
}
